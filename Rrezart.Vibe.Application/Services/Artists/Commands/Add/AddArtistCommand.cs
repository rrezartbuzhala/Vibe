using MediatR;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Artists.Commands.Add
{
    public class AddArtistCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public Artist ToEntity()
        {
            return new Artist
            {
                Id = Guid.NewGuid(),
                Name = Name,
            };
        }
    }
}
