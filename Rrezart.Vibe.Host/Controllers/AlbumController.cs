using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Albums.Commands;
using Rrezart.Vibe.Application.Services.Albums.Queries;
using System;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Controllers
{
    [Route("api/albums")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Add.Command command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Get.Query query)
        {
            var test = HttpContext.User;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route(":id")]
        public async Task<IActionResult> GetById([FromQuery] GetById.Query query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}