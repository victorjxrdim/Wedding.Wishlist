using Wedding.Wishlist.Domain.Enums;

namespace Wedding.Wishlist.Domain.Entities
{
    public class Wishlists
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = Category.Unknown;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int IsActive { get; set; } = 0;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
