namespace Wedding.Wishlist.Domain.Interfaces
{
    public interface IWishlistRepository
    {
        void UpdateWishlistStatus(Guid wishlistId);
    }
}
