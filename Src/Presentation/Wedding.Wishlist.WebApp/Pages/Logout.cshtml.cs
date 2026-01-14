using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LogoutModel(
    IHttpClientFactory factory)
    : PageModel
{  
    private readonly IHttpClientFactory _factory = factory;
    public async Task<IActionResult> OnGetAsync()
    {
        Response.Cookies.Delete("AuthToken");

        var client = _factory.CreateClient("WeddingWishlistWebApiClient");

        var httpResponse = await client.PostAsync($"/api/Auth/Logout", null);

        return RedirectToPage("/Index");
    }
}
