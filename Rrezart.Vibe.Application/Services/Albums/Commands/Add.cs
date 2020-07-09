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

namespace Rrezart.Vibe.Application.Services.Albums.Commands
{
    public class Add 
    {
        public class Command : IRequest
        {
            public Guid ArtistId { get; set; }
            public string Title { get; set; }
            public DateTime RealeaseDate { get; set; }
            public string CoverSource { get; set; }

            public Album ToEntity()
            {
                return new Album
                {
                    Id = Guid.NewGuid(),
                    ArtistId = ArtistId,
                    Title = Title,
                    ReleaseDate = RealeaseDate,
                    CoverSource = CoverSource,
                };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            private readonly IVibeDbContext _context;
            public CommandValidator(IVibeDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                Validations();
            }

            private void Validations()
            {
                RuleFor(x => x.ArtistId).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Artist Id must not be null")
                    .NotEmpty().WithMessage("Artist Id must not be empty")
                    .Must((artistId) =>
                    {
                        return _context.Artists.Any(x => x.Id == artistId);
                    }).WithMessage("Artist does not exist");

                RuleFor(x => x.Title).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Artist Id must not be null")
                    .NotEmpty().WithMessage("Artist Id must not be empty");

                RuleFor(x => x.CoverSource).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Cover source must not be null")
                   .NotEmpty().WithMessage("Cover source must not be empty");

                RuleFor(x => x.RealeaseDate).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Realease Date must not be null")
                   .NotEmpty().WithMessage("Realease Date must not be empty")
                   .LessThan(datetime => DateTime.Now).WithMessage("Incorrect date format");
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
                _context.Albums.Add(request.ToEntity());

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
        
    }
}
