using Core.Domain.Entities;

namespace Wedding.Wishlist.Domain.Entities
{
    public class Users
        : EntityByGuid<Guid>
    {        
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public string HashVersion { get; set; } = string.Empty;
        public int IsAdmin { get; set; } = 0;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    }
}
