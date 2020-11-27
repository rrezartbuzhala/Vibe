using FluentValidation;
using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Songs.Command
{
    public class Add
    {
        public class Command : IRequest
        {
            public Guid ArtistId { get; set; }
            public Guid AlbumId { get; set; }
            public Guid EnviromentId { get; set; }
            public string Title { get; set; }
            public string AudioSource { get; set; }
            public int Minutage { get; set; }
            public string CoverSource { get; set; }
            public string RegistredDate { get; set; }

            public IList<GenreCommand> Genres { get; set; } = new List<GenreCommand>();
            public IList<PlaylistCommand> Playlists { get; set; } = new List<PlaylistCommand>();

            public Song ToEntity()
            {
                return new Song
                {
                    Id = Guid.NewGuid(),
                    ArtistId = ArtistId,
                    AlbumId = AlbumId,
                    EnviromentId = EnviromentId,
                    Title = Title,
                    AudioSource = AudioSource,
                    Minutage = Minutage,
                    CoverSource = CoverSource,
                    RegistredDate = RegistredDate,
                    SongGenre = Genres.Select(genre => genre.ToEntity()).ToList(),
                    PlaylistSongs = Playlists.Select(playlist => playlist.ToEntity()).ToList()
                };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                CascadeMode = CascadeMode.StopOnFirstFailure;
                Validations();
            }
            private void Validations()
            {
               /* When(x => x.ArtistId != null, () =>
                {

                });*/
                RuleFor(x => x.ArtistId).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Artist Id must not be empty");

                RuleFor(x => x.AlbumId)
                    .NotEmpty().WithMessage("Album Id must not be empty");

                RuleFor(x => x.EnviromentId)
                    .NotEmpty().WithMessage("Enviroment Id must not be empty");

                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Title must not be empty");

                RuleFor(x => x.AudioSource).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Audio Source must not be null")
                    .NotEmpty().WithMessage("Audio Source must not be empty");

                RuleFor(x => x.Minutage).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Minutage must not be null")
                    .NotEmpty().WithMessage("Minutage must not be empty");

                RuleFor(x => x.CoverSource).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Cover source must not be null")
                    .NotEmpty().WithMessage("Cover source must not be empty");

                RuleFor(x => x.RegistredDate).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Registred date must not be null")
                    .NotEmpty().WithMessage("Registred date must not be empty");
            }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly IVibeDbContext _context;
            public CommandHandler(IVibeDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var song = request.ToEntity();
                _context.Songs.Add(song);
                await _context.SaveChangesAsync();
                return Unit.Value;


            }
        }

        public class GenreCommand
        {
            public Guid GenreId { get; set; }

            public SongGenre ToEntity()
            {
                return new SongGenre
                {
                    GenreId = GenreId
                };
            }
        }

        public class GenreCommandValidator : AbstractValidator<GenreCommand>
        {
            public GenreCommandValidator()
            {
                Validations();
            }

            private void Validations()
            {
                RuleFor(x => x.GenreId).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Genre Id must not be null")
                   .NotEmpty().WithMessage("Genre Id must not be empty");
            }
        }

        public class PlaylistCommand
        {
            public Guid PlaylistId { get; set; }

            public PlaylistSongs ToEntity()
            {
                return new PlaylistSongs
                {
                    PlaylistId = PlaylistId,
                };
            }
        }

        public class PlaylistCommandValidator : AbstractValidator<PlaylistCommand>
        {
            public PlaylistCommandValidator()
            {
                Validations();
            }

            private void Validations()
            {
                RuleFor(x => x.PlaylistId).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Playlist Id must not be null")
                   .NotEmpty().WithMessage("Playlist Id must not be empty");
            }
        }

    }
}


