namespace Wedding.Wishlist.Application.Responses
{
    public class CreateUserItemCommandResult(string message) 
    {
        public string Message { get; set; } = message;
    }
}
