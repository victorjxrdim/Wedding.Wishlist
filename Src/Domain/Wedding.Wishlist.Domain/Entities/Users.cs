using Core.Domain.Entities;

namespace Wedding.Wishlist.Domain.Entities
{
    public class Users
        : Entity<Guid>
    {        
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EncryptedPassword { get; set; } = string.Empty;
        public string HashVersion { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    }
}
