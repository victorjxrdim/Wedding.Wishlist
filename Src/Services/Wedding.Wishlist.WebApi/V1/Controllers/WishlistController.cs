using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.WebApi.V1.Contracts.Requests;

namespace Wedding.Wishlist.WebApi.V1.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController(
        IMediator mediator,
        IHttpContextAccessor httpContextAccessor)
        : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        [HttpPost]
        public async Task<IActionResult> CreateWishlistItem(CreateWishlistItemRequest request)
        {
            var command = request.ToCommand();

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetWishlists()
        {
            var query = new GetWishlistQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("{wishlistId}/user-item")]
        public async Task<IActionResult> CreateUserWishlistItem(string wishlistId)
        {
            var command = new CreateUserItemCommand(wishlistId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
