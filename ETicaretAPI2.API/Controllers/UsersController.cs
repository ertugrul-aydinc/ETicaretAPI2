using ETicaretAPI2.Application.Features.Commands.AppUser.CreateUser;
using ETicaretAPI2.Application.Features.Commands.AppUser.FacebookLogin;
using ETicaretAPI2.Application.Features.Commands.AppUser.GoogleLogin;
using ETicaretAPI2.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        
    }
}
