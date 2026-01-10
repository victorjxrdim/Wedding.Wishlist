using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wedding.Wishlist.Domain.Entities;

namespace Wedding.Wishlist.DataAccess.Data.Mappings
{
    internal class LogsMap : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.ToTable("LOGS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Type).HasColumnName("TYPE");
            builder.Property(x => x.RequestId).HasColumnName("REQUEST_ID");
            builder.Property(x => x.Message).HasColumnName("MESSAGE");
            builder.Property(x => x.Trace).HasColumnName("TRACE");
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT");
            builder.Property(x => x.TargetId).HasColumnName("TARGET_ID");            
            builder.Property(x => x.ReferenceType).HasColumnName("REFERENCE_TYPE");            
            builder.Property(x => x.ReferenceId).HasColumnName("REFERENCE_ID");            
            builder.Property(x => x.UsersId).HasColumnName("USERS_ID");            
        }
    }
}
