using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.RequestHandlers;
using Core.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.Application.RequestHandlers
{
    internal class GetWishlistQueryHandler(
        ILogger<GetWishlistQueryHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IServiceProvider serviceProvider,
        ICurrentUser currentUser)     
        : BaseRequestHandler<GetWishlistQuery, GetWishlistQueryResult>(logger, mapper, unitOfWork, serviceProvider, currentUser)
    {        
        public async override Task<GetWishlistQueryResult?> Execute(GetWishlistQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var wishlistRepository = _unitOfWork.Repository<Wishlists, Guid>();

                if (request.WishlistId != null)
                {
                    if(!Guid.TryParse(request.WishlistId, out Guid parsedId))
                    {
                        return BadRequest(request.GetValidationResult());
                    }

                    return Ok(new GetWishlistQueryResult(new List<WishlistsDto> 
                    { 
                        _mapper.Map<WishlistsDto>(await wishlistRepository.GetByIdAsync(parsedId, cancellationToken: cancellationToken)) 
                    }) );
                }
                
                var listWishlist = _mapper.Map<List<WishlistsDto>>(await wishlistRepository.ListAsync(cancellationToken: cancellationToken));

                return Ok(new GetWishlistQueryResult(listWishlist));
            }
            catch (Exception ex)
            {
                return InternalServerError($"Erro {ex}");
            }
        }
    }
}
