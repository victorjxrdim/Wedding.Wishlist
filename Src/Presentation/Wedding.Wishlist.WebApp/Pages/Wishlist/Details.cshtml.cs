using Microsoft.AspNetCore.Mvc.RazorPages;
using Wedding.Wishlist.WebApp.Contracts.Responses;
using Wedding.Wishlist.WebApp.ViewModels;

public class WishlistDetailsModel(
    IHttpClientFactory factory)
    : PageModel
{
    private readonly IHttpClientFactory _factory = factory;

    public WishlistItemViewModel Item { get; set; } = new();

    public async Task OnGetAsync(string wishlistId)
    {
        var client = _factory.CreateClient("WeddingWishlistWebApiClient");

        var response = await client.GetFromJsonAsync<GetWishlistResponse>($"/api/Wishlist/{wishlistId}");

        if (response?.Data?.Wishlist == null || response.Data.Wishlist.Count == 0)
        {
            return;
        }

        Item = response.Data.Wishlist.Select(x => new WishlistItemViewModel
        {
            Id = x.Id.ToString(),
            Name = x.Name,
            Description = x.Description,
            Category = x.Category,
            Url = x.Url,
            ProductImageUrl = x.ProductImageUrl,
            QrCodeUrl = x.QrCodeUrl,
            IsActive = x.IsActive
        }).FirstOrDefault()!;
    }
}
