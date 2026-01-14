using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public string Name { get; set; } = string.Empty;

    [BindProperty]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public string ConfirmPassword { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        // TODO: criar usuário real
        return RedirectToPage("/Login");
    }
}
