using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Enviroments.Queries.Get
{
    public class GetEnviromentsQuery : IRequest<IList<GetEnviromentsQueryModel>>
    {
    }
}
