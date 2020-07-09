using MediatR;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Commands.Add
{
    public class AddPlaylistCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string CoverSource { get; set; } = "link";

        public Playlist ToEntity()
        {
            return new Playlist
            {
                Id = Guid.NewGuid(),
                Title = Title,
                LastUpdated = DateTime.Now,
                CoverSource = CoverSource,
            };
        }
    }

   
}
