using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Songs.Queries.Get
{
    public class GetSongsQuery : IRequest<IList<GetSongsQueryModel>>
    {

    }
}
