using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.Application.Requests;
using Wedding.Wishlist.WebApi.V1.Contracts.Requests;

namespace Wedding.Wishlist.WebApi.V1.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController(
        IMediator mediator)
        : ControllerBase
    {
        private readonly IMediator _mediator = mediator;        

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateWishlistItemAsync(CreateWishlistItemRequest request)
        {
            var command = request.ToCommand();

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [HttpGet("{wishlistId}")]
        public async Task<IActionResult> GetWishlistsAsync(string? wishlistId = null)
        {
            var query = new GetWishlistQuery(wishlistId);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize]
        [HttpPost("{wishlistId}/user-item")]
        public async Task<IActionResult> CreateUserWishlistItemAsync(string wishlistId)
        {
            var command = new CreateUserItemCommand(wishlistId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{wishlistId}")]
        public async Task<IActionResult> EditWishlistAsync([FromBody] EditWishlistRequest request, string wishlistId)
        {
            var command = request.ToCommand(wishlistId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{wishlistId}")]
        public async Task<IActionResult> DeleteWishlistAsync(string wishlistId)
        {
            var command = new DeleteWishlistCommand(wishlistId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
