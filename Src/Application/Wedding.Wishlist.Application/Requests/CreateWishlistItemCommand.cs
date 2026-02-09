using Core.Application.Requests;
using FluentValidation;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;
using Wedding.Wishlist.Domain.Enums;

namespace Wedding.Wishlist.Application.Requests
{
    public class CreateWishlistItemCommand : BaseRequest<CreateWishlistItemCommand, CreateWishlistItemCommandResult>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = Category.Unknown;
        public string Url { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
        public string QrCodeUrl { get; set; } = string.Empty;

        public WishlistsDto ToDto()
        {
            return new WishlistsDto
            {
                Name = Name,
                Description = Description,
                Category = Category,
                Url = Url,
                ProductImageUrl = ProductImageUrl,
                QrCodeUrl = QrCodeUrl,
            };
        }

        protected override void OnValidatorConfiguring(RequestValidator validator)
        {
            validator.RuleFor(x => x.Name)
                .NotEmpty();

            validator.RuleFor(x => x.Category)
                .NotEqual(Category.Unknown);

            validator.RuleFor(x => x.Url)
                .NotEmpty();
        }
    }
}
