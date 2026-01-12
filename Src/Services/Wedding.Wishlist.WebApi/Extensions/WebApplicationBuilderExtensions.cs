using Core.Application.Extensions;
using Core.Application.Interfaces;
using Core.WebApi.Authentication;
using Core.WebApi.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Wedding.Wishlist.Application.Extensions;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.DataAccess.Data.Contexts;
using Wedding.Wishlist.DataAccess.Extensions;

namespace Wedding.Wishlist.WebApi.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        internal static WebApplicationBuilder ConfigureWebApi(this WebApplicationBuilder builder)
        {
            #region Default Configuration

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            #region Swagger 
            builder.Services.AddSwaggerGen(g =>
            {
                g.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Wedding.Wishlist.WebApi",
                    Version = "v1"
                });

                g.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Informe o token JWT no formato: Bearer {token}"
                });

                g.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            #endregion

            builder.Services.AddCoreMediatR(typeof(CreateWishlistItemCommand).Assembly);

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

            #region Application DI

            builder.Services.ConfigureApplication();
            builder.Services.ConfigureDataAccess(builder.Configuration);

            #endregion

            #region JWT Authentication

            builder.Services.Configure<JwtOptions>(
                builder.Configuration.GetSection(JwtOptions.SectionName));

            builder.Services.AddJwtAuthentication();

            builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
            builder.Services.AddScoped<ICookieAuthService, CookieAuthService>();
            builder.Services.AddScoped<ICurrentUser, CurrentUser>();

            #endregion

            return builder;
        }

        internal static void AddBaseWebApp(this WebApplication webApp)
        {
            if (webApp.Environment.IsDevelopment())
            {
                webApp.UseSwagger();
                webApp.UseSwaggerUI(swg =>
                {
                    swg.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    swg.RoutePrefix = "swagger";
                });
            }

            webApp.UseHttpsRedirection();
            webApp.UseRouting();
            webApp.UseCors("cors-default-policy");
            webApp.UseAuthentication();
            webApp.UseAuthorization();
            webApp.MapControllers();
        }

        internal static void RunMigration(this WebApplication webApp)
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

        internal static void ConfigureLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.SingleLine = true;
                options.TimestampFormat = "hh:mm:ss ";
            });
            builder.Logging.SetMinimumLevel(LogLevel.Information);
        }
    }
}
