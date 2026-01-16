using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.Application.Responses
{
    public class EditWishlistCommandResult(WishlistsDto? wishlistDto = null)
    {
        public WishlistsDto? Wishlist { get; set; } = wishlistDto;
    }
}
