using Dapper;
using Microsoft.EntityFrameworkCore;
using Wedding.Wishlist.DataAccess.Data.Contexts;
using Wedding.Wishlist.Domain.Interfaces;

namespace Wedding.Wishlist.DataAccess.Data.Repositories
{
    public class WishlistRepository(
        WeddingWishlistDbContext context) 
        : IWishlistRepository
    {
        private readonly WeddingWishlistDbContext _context = context;
        public void UpdateWishlistStatus(Guid wishlistId)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate("UPDATE WISHLISTS W SET W.IS_ACTIVE = 0 /**where**/");
                builder.Where("W.ID = :wishlistId", new { WishlistId = wishlistId.ToByteArray() });

                conn.Execute(query.RawSql, query.Parameters);

                return;
            }     
        }
    }
}
