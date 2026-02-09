using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.DataAccess.Data.Mappings
{
    internal class WishlistsMap : IEntityTypeConfiguration<Wishlists>
    {
        public void Configure(EntityTypeBuilder<Wishlists> builder)
        {
            builder.ToTable("WISHLISTS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasColumnName("NAME");
            builder.Property(x => x.Description).HasColumnName("DESCRIPTION");
            builder.Property(x => x.Category).HasColumnName("CATEGORY");
            builder.Property(x => x.Url).HasColumnName("URL");
            builder.Property(x => x.ProductImageUrl).HasColumnName("PRODUCT_IMAGE_URL");
            builder.Property(x => x.QrCodeUrl).HasColumnName("QR_CODE_URL");
            builder.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT");
        }
    }
}
