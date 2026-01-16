using Core.Application.Requests;
using FluentValidation;
using Wedding.Wishlist.Application.Responses;

namespace Wedding.Wishlist.Application.Requests
{
    public class DeleteWishlistCommand(string wishlistId) : BaseRequest<DeleteWishlistCommand, DeleteWishlistCommandResult>
    {
        public Guid WishlistId { get; set; } = Guid.TryParse(wishlistId, out Guid parsedId) ? parsedId : Guid.Empty;

        protected override void OnValidatorConfiguring(RequestValidator validator)
        {
            validator.RuleFor(x => x.WishlistId)
                .NotEqual(Guid.Empty);
        }
    }
}
