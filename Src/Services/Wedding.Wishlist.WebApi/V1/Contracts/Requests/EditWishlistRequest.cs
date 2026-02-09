using Wedding.Wishlist.Domain.Enums;
using Wedding.Wishlist.Application.Requests;

namespace Wedding.Wishlist.WebApi.V1.Contracts.Requests
{
    public class EditWishlistRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        public string? Url { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? QrCodeUrl { get; set; }

        public EditWishlistCommand ToCommand(string wishlistId)
        {
            var command = new EditWishlistCommand
            {
                Id = Guid.TryParse(wishlistId, out Guid parsedId) ? parsedId : Guid.Empty,
                Name = Name ?? string.Empty,
                Description = Description ?? string.Empty,
                Category = Category ?? Domain.Enums.Category.Unknown,
                Url = Url ?? string.Empty,
                ProductImageUrl = ProductImageUrl ?? string.Empty,
                QrCodeUrl = QrCodeUrl ?? string.Empty
            };

            return command;
        }
    }
}
