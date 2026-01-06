using Core.Domain.Entities;

namespace Wedding.Wishlist.Domain.Entities
{
    public class WishlistUserItem
        : Entity<Guid>
    {        
        public Guid UserId { get; set; }
        public Guid WishlistsId { get; set; }        
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
