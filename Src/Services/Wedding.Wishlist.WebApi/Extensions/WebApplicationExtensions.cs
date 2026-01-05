namespace Wedding.Wishlist.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void AddBaseWebApp(this WebApplication webApp)
        {
            webApp.UseCors("cors-default-policy");
            webApp.UseHttpsRedirection();
            webApp.UseAuthorization();
            webApp.UseAuthentication();
            webApp.MapControllers();
        }
    }
}
