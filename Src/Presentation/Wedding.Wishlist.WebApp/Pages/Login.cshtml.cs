using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class LoginModel(
    IHttpClientFactory factory)
    : PageModel
{
    private readonly IHttpClientFactory _factory = factory;

    [BindProperty]
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Password { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var client = _factory.CreateClient("WeddingWishlistWebApiClient");

        var httpResponse = await client.PostAsync($"/api/Auth/Login/{Email}/{Password}", null);

        if (!httpResponse.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Login inválido");
            return Page();
        }
        
        if (httpResponse.Headers.TryGetValues("Set-Cookie", out var cookies))
        {
            foreach (var cookie in cookies)
            {
                Response.Headers.Append("Set-Cookie", cookie);
            }
        }

        return RedirectToPage("/Index");
    }
}
