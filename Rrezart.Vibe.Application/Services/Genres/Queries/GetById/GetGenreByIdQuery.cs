using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Genres.Queries.GetById
{
    public class GetGenreByIdQuery : IRequest<GetGenreByIdQueryModel>
    {
        public Guid Id { get; set; }
    }
}
