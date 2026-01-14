using System.Net.Http.Headers;

namespace Wedding.Wishlist.WebApp.Handlers
{
    public class AuthenticatedHttpHandler(IHttpContextAccessor? httpContext = null)
        : DelegatingHandler
    {
        private readonly IHttpContextAccessor? _httpContext = httpContext;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(_httpContext is not null && _httpContext.HttpContext is not null)
            {
                if(_httpContext.HttpContext.Request.Cookies.TryGetValue("AuthToken", out string? token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
