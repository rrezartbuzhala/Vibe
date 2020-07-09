using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Artists.Commands.Add;
using Rrezart.Vibe.Application.Services.Artists.Queries.Get;
using Rrezart.Vibe.Application.Services.Artists.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Add([FromBody] AddArtistCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetArtistsQuery query)
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
