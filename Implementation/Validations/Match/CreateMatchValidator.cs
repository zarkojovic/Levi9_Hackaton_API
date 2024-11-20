using Application.DTO.Matches;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validations.Match
{
    public class CreateMatchValidator : AbstractValidator<CreateMatchDTO>
    {
        public CreateMatchValidator(AspContext context)
        {

            // Validate that Team1Id exists in the Teams table
            RuleFor(x => x.Team1Id)
                .Must(id => context.Teams.Any(t => t.Id == id))
                .WithMessage("Team with ID {PropertyValue} does not exist.");

            // Validate that Team2Id exists in the Teams table
            RuleFor(x => x.Team2Id)
                .Must(id => context.Teams.Any(t => t.Id == id))
                .WithMessage("Team with ID {PropertyValue} does not exist.");

            // Validate WinningTeamId:
            // - It can be null or empty.
            // - If not null, it must exist in the Teams table and match either Team1Id or Team2Id.
            RuleFor(x => x.WinningTeamId)
                .Must((dto, id) =>
                {
                    // If WinningTeamId is empty, skip this check
                    if (id == Guid.Empty || id == null)
                        return true;

                    // Check if the WinningTeamId exists and matches either Team1Id or Team2Id
                    return context.Teams.Any(t => t.Id == id) &&
                           (id == dto.Team1Id || id == dto.Team2Id);
                })
                .WithMessage("WinningTeamId must either be null or match Team1Id or Team2Id, and must exist in the database.");

            // Validate Duration: Minimum 1
            RuleFor(x => x.Duration)
                .GreaterThan(0)
                .WithMessage("Duration must be at least 1.");
        }
    }
}
