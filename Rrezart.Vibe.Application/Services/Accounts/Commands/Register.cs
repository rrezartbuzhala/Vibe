using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Rrezart.Vibe.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Accounts.Commands
{
    public class Register
    {
        public class Command : IRequest
        {
            public string Email { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public Guid RoleId { get; set; }

            public User ToEntity()
            {
                return new User
                {
                    Id = Guid.NewGuid(),
                    Email = Email,
                    UserName = UserName,
                    FirstName = FirstName,
                    LastName = LastName,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    
                };
            }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            public CommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
            {
                _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
                _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = request.ToEntity();

                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }
                await CreateClaims(request, user);

                await CreateRoles(request, user);

                return Unit.Value;
            }

            private async Task CreateRoles(Command request, User user)
            {
                var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, role.Name);
            }

            private async Task CreateClaims(Command request,User user)
            {
                var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
                IList<Claim> claims = new List<Claim>
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("Email",user.Email),
                    new Claim("UserName",user.UserName),
                    new Claim("FirstName",user.FirstName),
                    new Claim("LastName",user.LastName),
                    new Claim("EmailConfirmed",user.EmailConfirmed.ToString()),
                    new Claim("SecurityStamp",user.SecurityStamp.ToString()),
                    new Claim(ClaimTypes.Role, role.Name),
                };
                await _userManager.AddClaimsAsync(user, claims);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                Validations();
            }

            private void Validations()
            {
                RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Email must not be null")
                    .NotEmpty().WithMessage("Email must not be empty")
                    .EmailAddress().WithMessage("Email not valid");

                RuleFor(x => x.Password).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Password must not be null")
                    .NotEmpty().WithMessage("Password must not be empty");
            }
        }
    }
}
