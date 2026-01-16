using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.WebApi.V1.Contracts.Requests;

namespace Wedding.Wishlist.WebApi.V1.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(
        IMediator mediator)
        : ControllerBase
    {
        private readonly IMediator _mediator = mediator;        

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserRequest request)
        {
            var command = request.ToCommand();

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
