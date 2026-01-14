using Microsoft.AspNetCore.Mvc.RazorPages;

public class WishlistIndexModel : PageModel
{
    public List<WishlistItemViewModel> Items { get; set; } = [];

    public void OnGet()
    {
        Items =
        [
            new() { Id = "1", Name = "Jogo de Panelas", Description = "Aço inox", ImageUrl = "https://cdn.awsli.com.br/600x700/948/948882/produto/300789423/1000041242-masxaz437y.jpg" },
            new() { Id = "2", Name = "Cafeteira", Description = "Automática", ImageUrl = "https://sipolatti.vtexassets.com/arquivos/ids/201880/cafeteira-cp30-inox.jpg?v=638192559420530000" },
            new() { Id = "3", Name = "Aparelho de Jantar", Description = "Porcelana", ImageUrl = "https://m.media-amazon.com/images/I/6157FiXITGL._AC_UF894,1000_QL80_.jpg" }
        ];
    }
}

public class WishlistItemViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
