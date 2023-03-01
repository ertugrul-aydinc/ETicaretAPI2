using ETicaretAPI2.Application.Abstractions.Services;
using ETicaretAPI2.Application.Features.Commands.AppUser.CreateUser;
using ETicaretAPI2.Application.Features.Commands.AppUser.FacebookLogin;
using ETicaretAPI2.Application.Features.Commands.AppUser.GoogleLogin;
using ETicaretAPI2.Application.Features.Commands.AppUser.LoginUser;
using ETicaretAPI2.Application.Features.Commands.AppUser.UpdatePassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ETicaretAPI2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        readonly IMailService _mailService;
        readonly IMediator _mediator;

		public UsersController(IMediator mediator, IMailService mailService)
		{
			_mediator = mediator;
			_mailService = mailService;
		}

		[HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody]UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }
        
    }
}
