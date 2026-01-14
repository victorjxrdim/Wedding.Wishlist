using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.WebApp.Contracts.Requests;

namespace Wedding.Wishlist.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAppController(
        IHttpClientFactory factory,
        IServiceProvider serviceProvider)
        : ControllerBase
    {
        private readonly IHttpClientFactory _factory = factory;
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        private readonly HttpClient _httpClient = factory.CreateClient("WeddingWishlistWebApiClient");

        [HttpPost("User")]
        public async Task<IActionResult> CreateUserAsync(CreateUserRequest request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync($"/api/Users", request);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            return StatusCode((int)httpResponse.StatusCode, responseContent);
        }
    }
}
