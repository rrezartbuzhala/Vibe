using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Rrezart.Vibe.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Accounts.Commands
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            private readonly UserManager<User> _userManager;
            public CommandValidator(UserManager<User> userManager)
            {
                _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
                Validations();
            }

            private void Validations()
            {
                RuleFor(x => x.Id)
                    .NotNull().WithMessage("Account Id must not be null")
                    .NotEmpty().WithMessage("Account Id must not be empty")
                    .Must((id) =>
                    {
                        return _userManager.Users.Any(user => user.Id == id);
                    }).WithMessage("Account does not exits");
            }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly UserManager<User> _userManager;
            public CommandHandler(UserManager<User> userManager)
            {
                _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.Id.ToString());
                await _userManager.DeleteAsync(user);
                return Unit.Value;
            }
        }

       
    }
}
