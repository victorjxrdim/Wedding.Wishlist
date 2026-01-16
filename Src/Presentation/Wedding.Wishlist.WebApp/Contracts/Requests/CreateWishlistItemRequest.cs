namespace Wedding.Wishlist.WebApp.Contracts.Requests
{
    public class CreateWishlistItemRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Category { get; set; } = 0;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
