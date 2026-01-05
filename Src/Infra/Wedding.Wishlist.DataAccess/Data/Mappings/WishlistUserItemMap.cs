using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.DataAccess.Data.Mappings
{
    internal class WishlistUserItemMap : IEntityTypeConfiguration<WishlistUserItem>
    {
        public void Configure(EntityTypeBuilder<WishlistUserItem> builder)
        {
            builder.ToTable("WISHLIST_USER_ITEM");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.UserId).HasColumnName("USER_ID");
            builder.Property(x => x.WishlistsId).HasColumnName("WISHLIST_ID");
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT");
            builder.Property(x => x.UpdatedAt).HasColumnName("UPDATED_AT");

            builder.HasOne<Users>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Wishlists>()
                .WithMany()
                .HasForeignKey(x => x.WishlistsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
