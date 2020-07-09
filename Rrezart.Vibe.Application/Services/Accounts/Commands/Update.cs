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
    public class Update
    {
        public class Command : IRequest
        {
            internal Guid Id { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }


            public void SetInternalId(Guid id)
            {
                Id = id;
            }
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
                RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("User Id must not be null")
                    .NotEmpty().WithMessage("User Id must not be empty")
                    .Must((id) =>
                    {
                        return _userManager.Users.Any(user => user.Id == id);
                    }).WithMessage("User does not exit");

                RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Email must not be null")
                   .NotEmpty().WithMessage("Email must not be empty")
                   .EmailAddress().WithMessage("Email not valid");

                RuleFor(x => x.FirstName).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Firstname must not be null")
                   .NotEmpty().WithMessage("Firstname must not be empty");

                RuleFor(x => x.LastName).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Lastname must not be null")
                   .NotEmpty().WithMessage("Lastname must not be empty");

                RuleFor(x => x.UserName).Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("Username must not be null")
                   .NotEmpty().WithMessage("Username must not be empty");
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
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.UserName = request.UserName;
                user.Email = request.Email;
                await _userManager.UpdateAsync(user);

                return Unit.Value;
            }
        }
       
    }
}
