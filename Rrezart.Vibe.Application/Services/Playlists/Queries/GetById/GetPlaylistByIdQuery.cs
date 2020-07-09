using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Queries.GetById
{
    public class GetPlaylistByIdQuery : IRequest<GetPlaylistByIdQueryModel>
    {
        public Guid Id { get; set; }
    }
}
