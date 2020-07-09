using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Accounts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(":login")]
        public async Task<IActionResult> Login([FromBody] Login.Command command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpPost(":register")]
        public async Task<IActionResult> Register([FromBody] Register.Command command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete(":delete")]
        public async Task<IActionResult> Delete([FromQuery] Delete.Command command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(":update")]
        public async Task<IActionResult> Update([FromQuery] Guid id,[FromBody] Update.Command command)
        {
            command.SetInternalId(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
