using FluentValidation;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Enviroments.Queries.GetById
{
    public class GetEnviromentByIdQueryValidator : AbstractValidator<GetEnviromentByIdQuery>
    {
        private readonly IVibeDbContext _context;
        public GetEnviromentByIdQueryValidator(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Validations();
        }

        private void Validations()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull().WithMessage("Enviroment Id must not be null")
               .NotEmpty().WithMessage("Enviroment Id must not be empty")
               .Must((id) =>
               {
                   return _context.Enviroments.Any(x => x.Id == id);
               }
               ).WithMessage("Enviroment dosen't exist!");
        }
    }
}
