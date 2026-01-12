using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.RequestHandlers;
using Core.Domain.Interfaces;
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
        IServiceProvider serviceProvider,
        ICurrentUser currentUser)     
        : BaseRequestHandler<CreateUserItemCommand, CreateUserItemCommandResult>(logger, mapper, unitOfWork, serviceProvider, currentUser)
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
                var wishlistUserItemRepository = _unitOfWork.Repository<WishlistUserItem, Guid>();
                var wishlistRepository = _unitOfWork.Repository<Wishlists, Guid>();
                var userRepository = _unitOfWork.Repository<Users, Guid>();                

                var wishlist = await wishlistRepository.GetByIdAsync(command.WishlistId, cancellationToken);
                
                if (wishlist == null)
                {
                    return NotFound($"Wishlist with Id: {command.WishlistId} not found.");
                }

                var wishlistDto = _mapper.Map<WishlistsDto>(wishlist);

                var user = await userRepository.GetByIdAsync(_currentUser!.UserId, cancellationToken);

                if (user == null) 
                { 
                    return NotFound($"User with Id: {_currentUser.UserId} not found.");
                }

                var userItem = new WishlistUserItemDto()
                {
                    UserId = user.Id,
                    WishlistsId = wishlist.Id
                };                                
                                
                var wishlistUserItem = await wishlistUserItemRepository.CreateAsync(_mapper.Map<WishlistUserItem>(userItem), cancellationToken);                

                logService.CreateLog(LogType.Information, "New user item created.", referenceType: "WISHLIST_USER_ITEM", referenceId: wishlistUserItem!.Id.ToString(), usersId: user.Id);

                await _unitOfWork.CommitAsync(cancellationToken);

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
