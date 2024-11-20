using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validations.Player
{
    public class GetPlayerValidator : AbstractValidator<Guid>
    {
        public GetPlayerValidator(AspContext context)
        {
            RuleFor(x => x).NotEmpty();

            RuleFor(x => x).Must(id => context.Players.Any(x => x.Id == id)).WithMessage("Player not found.");
        }
    }
}
