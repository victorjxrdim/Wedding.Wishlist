using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.Application.Responses
{
    public class GetWishlistQueryResult(List<WishlistsDto>? wishlistDto = null)
    {
        public List<WishlistsDto>? Wishlist { get; set; } = wishlistDto;
    }
}
