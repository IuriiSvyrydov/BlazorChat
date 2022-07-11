using System;
using System.Threading.Tasks;
using BlazorChat.Api.Application.Features.Commands.GetUserDetail;
using BlazorChat.Api.Application.Features.Commands.User.ComfirmEmail;
using BlazorChat.Common.Events.User;
using BlazorChat.Common.Models.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorChat.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _mediator.Send(new GetUserDetailQuery(id));
            return Ok(user);
        }

        [HttpGet]
        [Route("UserName/{userName}")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var user = await _mediator.Send(new GetUserDetailQuery(Guid.Empty, userName));
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        
        public async Task<IActionResult> Login([FromBody] LoginUserCommand user)
        {
            var res = await _mediator.Send(user);
            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand user)
        {
            var guid = await _mediator.Send(user);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand user)
        {
            var guid = await _mediator.Send(user);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Confirm")]
        public async Task<IActionResult> ConfirmEmail(Guid id)
        {
            var guid = await _mediator.Send(new ComfirmEmailCommand
            {
                ConfirmationId = id
            });
            return Ok(guid);
        }

        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            if (!command.UserId.HasValue)
                command.UserId = UserId;
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }
    }

}
