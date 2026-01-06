using Wedding.Wishlist.Domain.Enums;
using Wedding.Wishlist.Application.Requests;

namespace Wedding.Wishlist.WebApi.V1.Contracts.Requests
{
    public class CreateWishlistItemRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Category { get; set; } = 0;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        
        public CreateWishlistItemCommand ToCommand()
        {
            var command = new CreateWishlistItemCommand
            {
                Name = Name,
                Description = Description,
                Category = (Category)Category,
                Url = Url,
                ImageUrl = ImageUrl
            };

            return command;
        }
    }
}
