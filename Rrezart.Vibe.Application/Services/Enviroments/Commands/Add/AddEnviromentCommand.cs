using MediatR;
using System;
using Rrezart.Vibe.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Enviroments.Commands.Add
{
    public class AddEnviromentCommand : IRequest<Unit>
    {
        public string EnviromentName { get; set; }

        public Enviroment ToEntity()
        {
            return new Enviroment
            {
                Id = Guid.NewGuid(),
                EnviromentName = EnviromentName
            };
        }
    }
}
