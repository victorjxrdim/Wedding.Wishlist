using Core.Application.Requests;
using FluentValidation;
using Wedding.Wishlist.Application.Responses;

namespace Wedding.Wishlist.Application.Requests
{
    public class LoginAuthCommand(string email, string password) 
        : BaseRequest<LoginAuthCommand, LoginAuthCommandResult>
    {
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;

        protected override void OnValidatorConfiguring(RequestValidator validator)
        {
            validator.RuleFor(x => x.Email)
                .NotEmpty();

            validator.RuleFor(x => x.Password)
                .NotEmpty();
        }   
    }
}
