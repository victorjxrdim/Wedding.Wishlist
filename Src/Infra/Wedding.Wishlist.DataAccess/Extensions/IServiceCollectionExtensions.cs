using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wedding.Wishlist.DataAccess.Data.Contexts;

namespace Wedding.Wishlist.DataAccess.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            #region Default

            services.AddDbContext<WeddingWishlistDbContext>(options => 
                options.UseOracle(
                    configuration.GetConnectionString("OracleConnection")
                )
            );          

            #endregion

            #region Repository

            #endregion

            return services;
        }
    }
}
