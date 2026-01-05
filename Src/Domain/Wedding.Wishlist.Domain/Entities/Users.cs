namespace Wedding.Wishlist.Domain.Entities
{
    public class Users
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EncryptedPassword { get; set; } = string.Empty;
        public string HashVersion { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    }
}
