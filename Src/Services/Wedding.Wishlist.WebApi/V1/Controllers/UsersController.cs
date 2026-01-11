using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.WebApi.V1.Contracts.Requests;

namespace Wedding.Wishlist.WebApi.V1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(
        IMediator mediator,
        IHttpContextAccessor httpContextAccessor)
        : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var command = request.ToCommand();

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
