using Core.Domain.Interfaces;
using Core.Infra.Data.UnitOfWork;
using Core.Infra.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wedding.Wishlist.DataAccess.Data.Contexts;
using Wedding.Wishlist.DataAccess.Data.Repositories;
using Wedding.Wishlist.Domain.Interfaces;

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

            services.AddScoped<IAppDbContext>(
                appContext => appContext.GetRequiredService<WeddingWishlistDbContext>()
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Repository

            services.AddScoped<IWishlistRepository, WishlistRepository>();

            #endregion

            return services;
        }
    }
}
