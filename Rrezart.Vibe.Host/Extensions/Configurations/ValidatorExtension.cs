using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Rrezart.Vibe.Application.Services.Songs.Command;

namespace Rrezart.Vibe.Host.Extensions.Configurations
{
    public static class ValidatorExtension
    {
        public static void UseValidations(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<Add.CommandValidator>();
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            }
            );
        }
    }
}
