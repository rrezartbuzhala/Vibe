using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Artists.Commands;
using Rrezart.Vibe.Application.Services.Artists.Queries;
using Rrezart.Vibe.Application.Services.Artists.Queries.GetById;
using System;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArtistController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Add.Command command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Get.Query query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route(":id")]
        public async Task<IActionResult> GetById([FromQuery] GetArtistByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

       

    }
}
