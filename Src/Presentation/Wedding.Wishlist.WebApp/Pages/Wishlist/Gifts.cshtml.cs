using Microsoft.AspNetCore.Mvc.RazorPages;
using Wedding.Wishlist.WebApp.Contracts.Responses;
using Wedding.Wishlist.WebApp.ViewModels;

public class WishlistIndexModel(
    IHttpClientFactory factory)
    : PageModel
{
    private readonly IHttpClientFactory _factory = factory;
    public List<WishlistItemViewModel> Items { get; set; } = [];

    public async Task OnGetAsync()
    {
        var client = _factory.CreateClient("WeddingWishlistWebApiClient");

        var response = await client.GetFromJsonAsync<GetWishlistResponse>("/api/Wishlist");

        if (response?.Data?.Wishlist == null || response.Data.Wishlist.Count == 0)
        {
            return;
        }            

        Items = response.Data.Wishlist.Select(x => new WishlistItemViewModel
        {
            Id = x.Id.ToString(),
            Name = x.Name,
            Description = x.Description,
            Category = x.Category,
            Url = x.Url,
            ImageUrl = x.ImageUrl,
            IsActive = x.IsActive
        }).ToList();
    }
}
