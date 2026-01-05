using Wedding.Wishlist.DataAccess.Extensions;

namespace Wedding.Wishlist.WebApi.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureWebApi(this WebApplicationBuilder builder)
        {
            #region Default Configuration
            
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.ConfigureDataAccess(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("cors-default-policy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();
                });
            });

            #endregion

            return builder; 
        }
    }
}
