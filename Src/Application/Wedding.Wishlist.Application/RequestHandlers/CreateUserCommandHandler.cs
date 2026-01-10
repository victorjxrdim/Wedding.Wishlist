using AutoMapper;
using Core.Application.RequestHandlers;
using Core.Domain.Interfaces;
using Core.Security.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;
using Wedding.Wishlist.Domain.Enums;
using Wedding.Wishlist.Domain.Interfaces;

namespace Wedding.Wishlist.Application.RequestHandlers
{
    internal class CreateUserCommandHandler(
        ILogger<CreateUserCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider)     
        : BaseRequestHandler<CreateUserCommand, CreateUserCommandResult>(logger, mapper, unitOfWork, serviceProvider)
    {        
        public override async Task<CreateUserCommandResult?> Execute(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }

            try
            {
                var logService = _serviceProvider.GetRequiredService<ILogService>();
                var usersRepository = _unitOfWork.Repository<Users, Guid>();
                var userDto = command.ToDto();

                var user = await usersRepository.GetWhereAsync(x => x.Email == userDto.Email, cancellationToken);

                if (user is not null)
                {
                    return Ok(new CreateUserCommandResult("User already exists."));
                }

                var (hashVersion, hashPassword) = Hash.CreateHash(command.Password);

                userDto.HashPassword = hashPassword;
                userDto.HashVersion = hashVersion;

                await usersRepository.CreateAsync(_mapper.Map<Users>(userDto), cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);

                logService.CreateLog(LogType.Information, "New user created.");

                return Ok(new CreateUserCommandResult("User successfully created."));
            }
            catch (Exception ex) 
            {
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
