using Core.Application.Requests;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.Application.Requests
{
    public class GetWishlistQuery(string? wishlistId = null) : BaseRequest<GetWishlistQuery, GetWishlistQueryResult>
    {
        public string? WishlistId { get; } = wishlistId;
    }
}
