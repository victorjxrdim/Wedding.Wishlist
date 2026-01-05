using Wedding.Wishlist.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureWebApi();

var app = builder.Build();

app.RunMigration();

app.AddBaseWebApp();

await app.RunAsync();
