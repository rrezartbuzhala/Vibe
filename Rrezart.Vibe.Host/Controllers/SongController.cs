using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Songs.Command;
using Rrezart.Vibe.Application.Services.Songs.Queries.Get;
using Rrezart.Vibe.Application.Services.Songs.Queries.GetById;
using System;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Controllers
{
    [ApiController]
    [Route("api/songs")]
    public class SongController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SongController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Add.Command command)
        {
            var result = await _mediator.Send(command);  
            return Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSongsQuery query)
        {
            var test = HttpContext.User;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route(":id")]
        public async Task<IActionResult> GetById([FromQuery] GetSongByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
      
    }
}
