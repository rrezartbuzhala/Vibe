using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rrezart.Vibe.Application.Exceptions;
using Rrezart.Vibe.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Accounts.Commands
{
    public class Login
    {
        public class Command : IRequest<Response>
        {
            public string Email { get; set; }
            public string Password { get; set; }
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

                RuleFor(request => request.Email).Cascade(CascadeMode.StopOnFirstFailure)
                    .EmailAddress().WithMessage("Email not valid")
                    .Must((email) =>
                    {
                        return _userManager.Users.Any(user => user.NormalizedEmail == email.ToUpper());
                    }).WithMessage("User not found");
            }
        }

        public class CommandHandler : IRequestHandler<Command, Response>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signManager;
            private readonly IConfiguration _configuration;

            public CommandHandler(UserManager<User> userManager, SignInManager<User> signManager, IConfiguration configuration)
            {
                _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
                _signManager = signManager ?? throw new ArgumentNullException(nameof(signManager));
                _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {

                var user = await _userManager.FindByEmailAsync(request.Email);
                /* if (user == null)
                 {
                     throw new Exception("User does not exist");
                 } */
                var response = await _signManager.PasswordSignInAsync(user, request.Password, true, false);
                if (!response.Succeeded)
                {
                    throw new PasswordIncorrectException();
                }


                var claims = await _userManager.GetClaimsAsync(user);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Authentication:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);


                return new Response
                {
                    AccessToken = tokenHandler.WriteToken(token),
                    Schema = JwtBearerDefaults.AuthenticationScheme,
                    ExpiresIn = tokenDescriptor.Expires
                };
            }
        }

        public class Response
        {
            public string AccessToken { get; set; }
            public DateTime? ExpiresIn { get; set; }
            public string Schema { get; set; }
        }

       

       
    }
}
