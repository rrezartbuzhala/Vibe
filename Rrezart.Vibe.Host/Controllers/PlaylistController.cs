using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Playlists.Commands.Add;
using Rrezart.Vibe.Application.Services.Playlists.Commands.AddSong;
using Rrezart.Vibe.Application.Services.Playlists.Queries.Get;
using Rrezart.Vibe.Application.Services.Playlists.Queries.GetById;
using System;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Controllers
{
    [ApiController]
    [Route("/api/playlists")]
    public class PlaylistController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlaylistController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPlaylistCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route(":add-song")]
        public async Task<IActionResult> AddSong([FromBody] AddSongToPlaylistCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPlaylistsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route(":id")]
        public async Task<IActionResult> GetById([FromQuery] GetPlaylistByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        
    }
}
