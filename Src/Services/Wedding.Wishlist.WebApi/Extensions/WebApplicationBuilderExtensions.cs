using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Wedding.Wishlist.DataAccess.Data.Contexts;
using Wedding.Wishlist.DataAccess.Extensions;

namespace Wedding.Wishlist.WebApi.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureWebApi(this WebApplicationBuilder builder)
        {
            #region Default Configuration
            
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(g =>
            {
                g.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Wedding Wishlist API",
                    Version = "v1"
                });
            });

            builder.Services.ConfigureDataAccess(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("cors-default-policy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            #endregion

            return builder;
        }

        public static void AddBaseWebApp(this WebApplication webApp)
        {
            if (webApp.Environment.IsDevelopment())
            {
                webApp.UseSwagger();
                webApp.UseSwaggerUI(swg =>
                {
                    swg.SwaggerEndpoint("/swagger/v1/swagger.json", "Wedding.Wishlist.WebApi v1");
                    swg.RoutePrefix = string.Empty;
                });
            }
            
            webApp.UseHttpsRedirection();
            webApp.UseAuthentication();
            webApp.UseAuthorization();
            webApp.UseCors("cors-default-policy");
            webApp.MapControllers();
        }

        public static void RunMigration(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WeddingWishlistDbContext>();

                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao aplicar migration: {ex}");
                    throw;
                }
            }
        }
    }
}
