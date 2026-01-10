namespace Wedding.Wishlist.Application.Responses
{
    public class CreateUserCommandResult(string message) 
    {
        public string Message { get; set; } = message;
    }
}
