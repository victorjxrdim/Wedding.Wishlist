using Core.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wedding.Wishlist.Application.Requests;

namespace Wedding.Wishlist.WebApi.V1.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        IMediator mediator,
        ICookieAuthService cookieAuthService)
        : ControllerBase
    {
        private readonly IMediator _mediator = mediator;                       
        private readonly ICookieAuthService _cookieAuthService = cookieAuthService;
        
        [HttpPost("Login/{email}/{password}")]
        public async Task<IActionResult> LoginAsync(string email, string password)
        {
            var command = new LoginAuthCommand(email, password);

            var result = await _mediator.Send(command);

            if (result.StatusCode == 200)
            {
                _cookieAuthService.SetCookie(result.Data!.Token!);
                return Ok();
            }

            return Unauthorized();
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            _cookieAuthService.Clear();
            return Ok();
        }       
    }
}
