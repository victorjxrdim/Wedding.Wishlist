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
                
                var getWishlist = await wishlistsRepository.GetByIdAsync(command.Id);

                if (getWishlist == null)
                {
                    return NotFound($"Wishlist com Id {command.Id} não encontrado.");
                }

                var wishlistDto = _mapper.Map<WishlistsDto>(getWishlist);

                wishlistDto.Name = command.Name ?? wishlistDto.Name;
                wishlistDto.Description = command.Description ?? wishlistDto.Description;
                wishlistDto.Category = command.Category != 0 ? command.Category : wishlistDto.Category;
                wishlistDto.Url = command.Url ?? wishlistDto.Url;
                wishlistDto.ImageUrl = command.ImageUrl ?? wishlistDto.ImageUrl;

                var updateWishlist = wishlistsRepository.Update(_mapper.Map<Wishlists>(wishlistDto));

                logService.CreateLog(LogType.Information, "Wishlist item edited", referenceType: "WISHLISTS", referenceId: updateWishlist!.Id.ToString(), usersId: _currentUser!.UserId);

                await _unitOfWork.CommitAsync();

                return Ok(new EditWishlistCommandResult(wishlistDto));
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creating user.");
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
