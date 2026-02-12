using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.WebApp.Contracts.Requests;
using Wedding.Wishlist.WebApp.Contracts.Responses;

namespace Wedding.Wishlist.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAppController(
        IHttpClientFactory factory)
        : ControllerBase
    {
        private readonly HttpClient _httpClient = factory.CreateClient("WeddingWishlistWebApiClient");

        [IgnoreAntiforgeryToken]
        [HttpPost("User")]
        public async Task<IActionResult> CreateUserAsync(CreateUserRequest request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync($"/api/Users", request);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            return StatusCode((int)httpResponse.StatusCode, responseContent);
        }

        [HttpPost("Wishlists/Item")]
        public async Task<IActionResult> CreateWishlistItemAsync(CreateWishlistItemRequest request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync($"/api/Wishlist", request);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            return StatusCode((int)httpResponse.StatusCode, responseContent);
        }

        [HttpDelete("Wishlists/{wishlistId}")]
        public async Task<IActionResult> DeleteWishlistAsync(string wishlistId)
        {
            var httpResponse = await _httpClient.DeleteAsync($"/api/Wishlist/{wishlistId}");

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            return StatusCode((int)httpResponse.StatusCode, responseContent);
        }

        [HttpPut("Wishlist/Edit/{wishlistId}")]
        public async Task<IActionResult> EditWishlistAsync([FromBody] EditWishlistRequest request, string wishlistId)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync($"/api/Wishlist/{wishlistId}", request);

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            return StatusCode((int)httpResponse.StatusCode, responseContent);
        }

        [HttpGet("Wishlist/{wishlistId}")]
        public async Task<IActionResult> GetWishlistsAsync(string wishlistId)
        {
            var httpResponse = await _httpClient.GetFromJsonAsync<GetWishlistResponse>($"/api/Wishlist/{wishlistId}");

            if (httpResponse == null)
            {
                return NotFound();
            }
            
            return Ok(httpResponse.Data.Wishlist.FirstOrDefault());
        }
    }
}