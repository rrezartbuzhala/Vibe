using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Genres.Commands.Add;
using Rrezart.Vibe.Application.Services.Genres.Queries.Get;
using Rrezart.Vibe.Application.Services.Genres.Queries.GetById;
using System;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        private IMediator _mediator; 
        public GenreController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddGenreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetGenresQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route(":id")]
        public async Task<IActionResult> GetById([FromQuery] GetGenreByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
