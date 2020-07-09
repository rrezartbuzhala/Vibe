using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Songs.Queries.GetById
{
    public class GetSongByIdQuery : IRequest<GetSongByIdQueryModel>
    {
        public Guid Id { get; set; }
    }
}
