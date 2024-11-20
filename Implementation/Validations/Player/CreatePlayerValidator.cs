using Application.DTO.Players;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validations.Player
{
    public class CreatePlayerValidator : AbstractValidator<CreatePlayerDTO>
    {

        public CreatePlayerValidator(AspContext context)
        {
            // make it unique in the database
            RuleFor(x => x.Nickname)
                .NotEmpty()
                .WithMessage("Nickname is required.")
                .MaximumLength(30)
                .WithMessage("Nickname must have a maximum of 30 characters.")
                .Must((dto, nickname) => !context.Players.Any(x => x.Nickname == nickname))
                .WithMessage("Nickname must be unique.");
        }
    }
}
