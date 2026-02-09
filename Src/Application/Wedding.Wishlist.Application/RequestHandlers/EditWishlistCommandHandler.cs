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
    internal class EditWishlistCommandHandler(
        ILogger<EditWishlistCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider,
        ICurrentUser currentUser)     
        : BaseRequestHandler<EditWishlistCommand, EditWishlistCommandResult>(logger, mapper, unitOfWork, serviceProvider, currentUser)
    {        
        public override async Task<EditWishlistCommandResult?> Execute(EditWishlistCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }

            try
            {
                var logService = _serviceProvider.GetRequiredService<ILogService>();
                var wishlistsRepository = _unitOfWork.Repository<Wishlists, Guid>();

                var wishlist = await wishlistsRepository.GetByIdAsync(command.Id);

                if (wishlist == null)
                {
                    return NotFound($"Wishlist with id: {command.Id} cannot be found.");
                }

                wishlist.Name = command.Name ?? wishlist.Name;
                wishlist.Description = command.Description ?? wishlist.Description;
                wishlist.Category = command.Category != 0 ? command.Category : wishlist.Category;
                wishlist.Url = command.Url ?? wishlist.Url;
                wishlist.ProductImageUrl = command.ProductImageUrl ?? wishlist.ProductImageUrl;
                wishlist.QrCodeUrl = command.QrCodeUrl ?? wishlist.QrCodeUrl;

                await _unitOfWork.CommitAsync();

                logService.CreateLog(
                    LogType.Information,
                    "Wishlist item edited",
                    referenceType: "WISHLISTS",
                    referenceId: wishlist.Id.ToString(),
                    usersId: _currentUser!.UserId
                );

                return Ok(new EditWishlistCommandResult(
                    _mapper.Map<WishlistsDto>(wishlist)
                ));

            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creating user.");
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
