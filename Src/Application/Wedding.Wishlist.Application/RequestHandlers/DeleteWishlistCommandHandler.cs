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
using Wedding.Wishlist.Domain.Enums;
using Wedding.Wishlist.Domain.Interfaces;

namespace Wedding.Wishlist.Application.RequestHandlers
{
    internal class DeleteWishlistCommandHandler(
        ILogger<DeleteWishlistCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider,
        ICurrentUser currentUser)     
        : BaseRequestHandler<DeleteWishlistCommand, DeleteWishlistCommandResult>(logger, mapper, unitOfWork, serviceProvider, currentUser)
    {        
        public override async Task<DeleteWishlistCommandResult?> Execute(DeleteWishlistCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }

            try
            {
                var logService = _serviceProvider.GetRequiredService<ILogService>();
                var wishlistsRepository = _unitOfWork.Repository<Wishlists, Guid>();
                var wishlistsItemsRepository = _unitOfWork.Repository<WishlistUserItem, Guid>();

                var getWishlist = await wishlistsRepository.GetByIdAsync(command.WishlistId, cancellationToken);

                if (getWishlist == null)
                {
                    return NotFound($"Wishlist com Id {command.WishlistId} não encontrado.");
                }

                var getUserItem = await wishlistsItemsRepository.GetWhereAsync(x => x.WishlistsId == command.WishlistId, cancellationToken);

                if (getUserItem is not null)
                {
                    wishlistsItemsRepository.Delete(getUserItem);
                    logService.CreateLog(LogType.Information, "Wishlist user item deleted.", referenceType: "WISHLISTS_USER_ITEM", referenceId: getUserItem.Id.ToString(), usersId: _currentUser!.UserId);
                }

                wishlistsRepository.Delete(getWishlist);

                logService.CreateLog(LogType.Information, "Wishlist item deleted.", referenceType: "WISHLISTS", referenceId: getWishlist.Id.ToString(), usersId: _currentUser!.UserId);

                await _unitOfWork.CommitAsync();

                return Ok(new DeleteWishlistCommandResult(true));
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creating user.");
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
