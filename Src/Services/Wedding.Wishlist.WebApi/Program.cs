using Wedding.Wishlist.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .ConfigureWebApi();

builder.ConfigureLogging();

var app = builder.Build();

app.RunMigration();

app.AddBaseWebApp();

await app.RunAsync();
