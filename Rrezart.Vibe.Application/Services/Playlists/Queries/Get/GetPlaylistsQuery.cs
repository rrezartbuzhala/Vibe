using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Queries.Get
{
    public class GetPlaylistsQuery : IRequest<IList<GetPlaylistsQueryModel>>
    {
    }
}
