using Core.Application.Requests;
using FluentValidation;
using Wedding.Wishlist.Application.Responses;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.Application.Requests
{
    public class CreateUserCommand : BaseRequest<CreateUserCommand, CreateUserCommandResult>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UsersDto ToDto()
        {
            return new UsersDto
            {
                Name = Name,
                Email = Email, 
                HashPassword = Password
            };
        }

        protected override void OnValidatorConfiguring(RequestValidator validator)
        {
            validator.RuleFor(x => x.Name)
                .NotEmpty();

            validator.RuleFor(x => x.Email)
                .NotEmpty();

            validator.RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
