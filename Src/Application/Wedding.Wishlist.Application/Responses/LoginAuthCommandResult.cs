namespace Wedding.Wishlist.Application.Responses
{
    public class LoginAuthCommandResult(string? authToken = null, string? message = null)
    {
        public string? Token { get; set; } = authToken;
        public string? Message { get; set; } = message;
    }
}
