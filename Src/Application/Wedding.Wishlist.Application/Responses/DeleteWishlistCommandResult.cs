namespace Wedding.Wishlist.Application.Responses
{
    public class DeleteWishlistCommandResult(bool isDeleted)
    {
        public bool IsDeleted { get; } = isDeleted;
    }
}
