using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.RequestHandlers;
using Core.Domain.Interfaces;
using Core.Security.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;
using Wedding.Wishlist.Domain.Interfaces;

namespace Wedding.Wishlist.Application.RequestHandlers
{
    internal class LoginAuthCommandHandler(
        ILogger<LoginAuthCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider)     
        : BaseRequestHandler<LoginAuthCommand, LoginAuthCommandResult>(logger, mapper, unitOfWork, serviceProvider)
    {        
        public override async Task<LoginAuthCommandResult?> Execute(LoginAuthCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }

            try
            {
                var tokenGenerator = _serviceProvider.GetRequiredService<ITokenGenerator>();
                var logService = _serviceProvider.GetRequiredService<ILogService>();
                var usersRepository = _unitOfWork.Repository<Users, Guid>();

                var user = await usersRepository.GetWhereAsync(x => x.Email == command.Email, cancellationToken);

                if (user == null)
                {
                    return Unauthorized(new LoginAuthCommandResult(message: "User not found."));
                }

                if (!Hash.VerifyHash(command.Password, user.HashPassword))
                {
                    return Unauthorized(new LoginAuthCommandResult(message: "Invalid password."));
                }

                var token = tokenGenerator.GenerateToken(user.Id, user.Email, user.Name, user.IsAdmin);

                return Ok(new LoginAuthCommandResult(authToken: token));

            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creating user.");
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
