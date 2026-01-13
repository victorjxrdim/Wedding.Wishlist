using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class WishlistDetailsModel : PageModel
{
    public WishlistItemViewModel Item { get; set; } = new();

    public void OnGet(string id)
    {
        Item = new()
        {
            Id = id,
            Name = "Presente Exemplo",
            Description = "Descrição completa do presente",
            ImageUrl = "https://via.placeholder.com/600"
        };
    }
}
