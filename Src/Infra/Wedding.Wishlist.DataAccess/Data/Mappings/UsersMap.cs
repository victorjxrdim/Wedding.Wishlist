using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.DataAccess.Data.Mappings
{
    internal class UsersMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("USERS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasColumnName("NAME");
            builder.Property(x => x.Email).HasColumnName("EMAIL");
            builder.Property(x => x.EncryptedPassword).HasColumnName("ENCRYPTED_PASSWORD");
            builder.Property(x => x.HashVersion).HasColumnName("HASH_VERSION");
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT");
        }
    }
}
