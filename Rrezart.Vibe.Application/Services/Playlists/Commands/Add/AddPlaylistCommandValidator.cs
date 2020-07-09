using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Commands.Add
{
    public class AddPlaylistCommandValidator : AbstractValidator<AddPlaylistCommand>
    {
        public AddPlaylistCommandValidator()
        {
            Validations();
        }
        private void Validations()
        {
            RuleFor(x => x.Title).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Title must not be null!")
                .NotEmpty().WithMessage("Title must not be empty")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CoverSource).Cascade(CascadeMode.StopOnFirstFailure)
                        .NotNull().WithMessage("Cover Source must not be null!")
                        .NotEmpty().WithMessage("Cover Source must not be empty");
                });
            
        }
    }
}
