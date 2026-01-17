namespace Wedding.Wishlist.WebApp.Contracts.Requests
{
    public class EditWishlistRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Category { get; set; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }
    }
}
