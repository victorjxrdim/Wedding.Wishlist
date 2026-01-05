using Microsoft.EntityFrameworkCore;
using Wedding.Wishlist.DataAccess.Data.Mappings;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.DataAccess.Data.Contexts
{
    public class WeddingWishlistContext(DbContextOptions options)
        : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Wishlists> Wishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new WishlistsMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
