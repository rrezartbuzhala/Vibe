using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Albums.Queries
{
    public class GetById
    {
        public class Query : IRequest<Response>
        {
            public Guid Id { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            private readonly IVibeDbContext _context;

            public QueryValidator(IVibeDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                CascadeMode = CascadeMode.StopOnFirstFailure;
                Validations();
            }

            private void Validations()
            {
                RuleFor(x => x.Id)
                    .NotNull().WithMessage("Album Id must not be null")
                    .NotEmpty().WithMessage("Album Id must not be empty")
                    .Must((albumId) =>
                    {
                        return _context.Albums.Any(album => album.Id == albumId);
                    }).WithMessage("Album not found");

            }
        }

        public class QueryHandler : IRequestHandler<Query, Response>
        {
            private readonly IVibeDbContext _context;

            public QueryHandler(IVibeDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context
                    .Albums
                    .Where(a => a.Id == request.Id)
                    .Select(album => new Response
                    {
                        Artist = new ArtistModel
                        {
                            Name = album.Artist.Name
                        },
                        Title = album.Title,
                        ReleaseDate = album.ReleaseDate,
                        CoverSource = album.CoverSource,
                        Songs = album.Songs.Select(songs => new SongModel
                        {
                            Id = songs.Id,
                            Title = songs.Title,

                        }),


                    }).FirstOrDefaultAsync();
            }
        }

        public class Response
        {
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string CoverSource { get; set; }

            public ArtistModel Artist { get; set; }
            public IEnumerable<SongModel> Songs { get; set; } = new List<SongModel>();
        }      
    }
}
