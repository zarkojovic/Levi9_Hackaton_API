using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validations.Team
{
    public class GetTeamValidator : AbstractValidator<Guid>
    {
        public GetTeamValidator(AspContext context)
        {
            RuleFor(x => x)
                .Must(id => context.Teams.Any(t => t.Id == id))
                .WithMessage("Team with id of {PropertyValue} does not exist.");
        }
    }
}
