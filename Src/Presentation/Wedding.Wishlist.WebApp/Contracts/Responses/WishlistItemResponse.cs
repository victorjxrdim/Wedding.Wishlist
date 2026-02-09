namespace Wedding.Wishlist.WebApp.Contracts.Responses;

public class GetWishlistResponse
{
    public WishlistData Data { get; set; } = new();
}

public class WishlistData
{
    public List<WishlistItemResponse> Wishlist { get; set; } = [];
}

public class WishlistItemResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Category { get; set; } = 0;
    public string Url { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;
    public string QrCodeUrl { get; set; } = string.Empty;
    public int IsActive { get; set; } = 0;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
