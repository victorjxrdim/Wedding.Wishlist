using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wedding.Wishlist.DataAccess.Data.Mappings;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.DataAccess.Data.Contexts
{
    public class WeddingWishlistDbContext(DbContextOptions options)
        : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Wishlists> Wishlists { get; set; }
        public DbSet<WishlistsItem> WishlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new WishlistsMap());
            modelBuilder.ApplyConfiguration(new WishlistsItemMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
