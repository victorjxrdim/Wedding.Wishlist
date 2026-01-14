using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.WebApi.V1.Contracts.Requests;

namespace Wedding.Wishlist.WebApi.V1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController(
        IMediator mediator,
        IHttpContextAccessor httpContextAccessor)
        : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateWishlistItemAsync(CreateWishlistItemRequest request)
        {
            var command = request.ToCommand();

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetWishlistsAsync()
        {
            var query = new GetWishlistQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("{wishlistId}/user-item")]
        public async Task<IActionResult> CreateUserWishlistItemAsync(string wishlistId)
        {
            var command = new CreateUserItemCommand(wishlistId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
