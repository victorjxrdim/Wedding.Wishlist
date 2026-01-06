using Core.Application.Requests;
using FluentValidation;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Enums;

namespace Wedding.Wishlist.Application.Requests
{
    internal class CreateWishlistItemCommand : BaseRequest<CreateWishlistItemCommand, CreateWishlistItemResult>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = Category.Unknown;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        protected override void OnValidatorConfiguring(RequestValidator validator)
        {
            validator.RuleFor(x => x.Name)
                .NotEmpty();

            validator.RuleFor(x => x.Category)
                .Must(x => x != Category.Unknown);

            validator.RuleFor(x => x.Url)
                .NotEmpty();
        }
    }
}
