using Core.Application.Requests;
using FluentValidation;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.Application.Requests
{
    public class CreateUserItemCommand(string wishlistId) : BaseRequest<CreateUserItemCommand, CreateUserItemCommandResult>
    {
        public Guid WishlistId { get; set; } = Guid.TryParse(wishlistId, out Guid parsedWishlistId) ? parsedWishlistId : Guid.Empty;
        public WishlistUserItemDto ToDto()
        {
            return new WishlistUserItemDto
            {
                WishlistsId = WishlistId
            };
        }

        protected override void OnValidatorConfiguring(RequestValidator validator)
        {
            validator.RuleFor(x => x.WishlistId)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
