using Core.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Wedding.Wishlist.Application.Services;
using Wedding.Wishlist.Domain.Entities;
using Wedding.Wishlist.Domain.Interfaces;

namespace Wedding.Wishlist.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<ILogService, LogService>();            

            #endregion

            #region AutoMapper

            services.AddAutoMapper(x =>
            {
                #region Entity - DTO

                x.CreateMap<Users, UsersDto>().ReverseMap();
                x.CreateMap<Wishlists, WishlistsDto>().ReverseMap();
                x.CreateMap<WishlistUserItem, WishlistUserItemDto>().ReverseMap();

                #endregion

                #region DTO - Results
                #endregion
            });

            #endregion

            return services;
        }
    }
}
