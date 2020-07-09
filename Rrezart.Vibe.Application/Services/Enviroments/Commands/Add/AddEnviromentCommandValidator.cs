using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Enviroments.Commands.Add
{
    public class AddEnviromentCommandValidator : AbstractValidator<AddEnviromentCommand>
    {
        public AddEnviromentCommandValidator()
        {
            Validations();
        }

        private void Validations()
        {

        }
    }
}
