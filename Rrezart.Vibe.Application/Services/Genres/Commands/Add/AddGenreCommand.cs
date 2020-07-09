using MediatR;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Genres.Commands.Add
{
    public class AddGenreCommand : IRequest<Unit>
    {
        public string GenreName { get; set; }

        public Genre ToEntity()
        {
            return new Genre
            {
                Id = Guid.NewGuid(),
                GenreName = GenreName,
            };
        }
    }
}
