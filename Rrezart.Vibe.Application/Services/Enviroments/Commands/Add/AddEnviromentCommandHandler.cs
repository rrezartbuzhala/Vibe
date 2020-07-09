using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Enviroments.Commands.Add
{
    public class AddEnviromentCommandHandler : IRequestHandler<AddEnviromentCommand, Unit>
    {
        private readonly IVibeDbContext _context;

        public AddEnviromentCommandHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddEnviromentCommand request, CancellationToken cancellationToken)
        {
            _context.Enviroments.Add(request.ToEntity());

            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
