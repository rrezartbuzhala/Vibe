using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Genres.Queries.Get
{
    public class GetGenresQuery : IRequest<IList<GetGenresQueryModel>>
    {

    }
}
