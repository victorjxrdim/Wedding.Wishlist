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
    internal class CreateUserItemCommandHandler(
        ILogger<CreateUserItemCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider)     
        : BaseRequestHandler<CreateUserItemCommand, CreateUserItemCommandResult>(logger, mapper, unitOfWork, serviceProvider)
    {        
        public override async Task<CreateUserItemCommandResult?> Execute(CreateUserItemCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }

            try
            {
                var logService = _serviceProvider.GetRequiredService<ILogService>();

                logService.CreateLog(LogType.Information, "New user item created.", referenceType: "WISHLIST_USER_ITEM");

                return Ok(new CreateUserItemCommandResult("Item successfully created."));
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creating user.");
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
