using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Artists.Queries.Get
{
    public class GetArtistsQuery : IRequest<IList<GetArtistsQueryModel>>
    {
    }
}
