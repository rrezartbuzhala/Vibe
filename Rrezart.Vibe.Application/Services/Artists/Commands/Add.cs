using FluentValidation;
using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Artists.Commands
{
    public class Add
    {
        public class Command : IRequest
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

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                Validations();
                CascadeMode = CascadeMode.StopOnFirstFailure;
            }
            public void Validations()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name must not be empty!");
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
                _context.Artists.Add(request.ToEntity());
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
