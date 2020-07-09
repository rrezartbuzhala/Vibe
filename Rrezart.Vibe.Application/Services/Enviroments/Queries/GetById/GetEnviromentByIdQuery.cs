using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Enviroments.Queries.GetById
{
    public class GetEnviromentByIdQuery : IRequest<GetEnviromentByIdQueryModel>
    {
        public Guid Id { get; set; }
    }
}
