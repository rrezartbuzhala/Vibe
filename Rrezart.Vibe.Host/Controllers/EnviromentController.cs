using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rrezart.Vibe.Application.Services.Enviroments.Commands.Add;
using Rrezart.Vibe.Application.Services.Enviroments.Queries.Get;
using Rrezart.Vibe.Application.Services.Enviroments.Queries.GetById;

namespace Rrezart.Vibe.Host.Controllers
{
    [Route("api/enviroment")]
    [ApiController]
    public class EnviromentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnviromentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEnviromentCommand command)
        {
            await _mediator.Send(command);

            return Ok("Enviroment has been registred");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEnviromentsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route(":id")]
        public async Task<IActionResult> GetById([FromQuery] GetEnviromentByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}