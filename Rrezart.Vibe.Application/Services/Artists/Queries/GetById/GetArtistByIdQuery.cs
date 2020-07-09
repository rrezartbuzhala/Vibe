using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Artists.Queries.GetById
{
    public class GetArtistByIdQuery : IRequest<GetArtistByIdQueryModel>
    {
        public Guid Id { get; set; }
    }
}
