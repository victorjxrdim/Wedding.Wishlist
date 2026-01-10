using Wedding.Wishlist.Domain.Enums;
using Wedding.Wishlist.Application.Requests;

namespace Wedding.Wishlist.WebApi.V1.Contracts.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public CreateUserCommand ToCommand()
        {
            var command = new CreateUserCommand
            {
                Name = Name,
                Email = Email,
                Password = Password
            };

            return command;
        }
    }
}
