using AutoMapper;
using Core.Application.RequestHandlers;
using Core.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.Application.RequestHandlers
{
    internal class CreateWishlistItemCommandHandler(
        ILogger<CreateWishlistItemCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider)     
        : BaseRequestHandler<CreateWishlistItemCommand, CreateWishlistItemCommandResult>(logger, mapper, unitOfWork, serviceProvider)
    {        
        public override async Task<CreateWishlistItemCommandResult?> Execute(CreateWishlistItemCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return BadRequest(command.GetValidationResult());
            }

            try
            {
                var wishlistRepository = _unitOfWork.Repository<Wishlists, Guid>();                
                var wishlistDto = command.ToDto();

                var createNewWishlist = _mapper.Map<Wishlists>(wishlistDto);

                await wishlistRepository.CreateAsync(createNewWishlist, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);

                return Ok(new CreateWishlistItemCommandResult());
            }
            catch (Exception ex) 
            {
                return InternalServerError($"Erro {ex}");
            }            
        }
    }
}
