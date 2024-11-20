using Application.DTO.Teams;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validations.Team
{
    public class CreateTeamValidator : AbstractValidator<CreateTeamDTO>
    {
        private readonly AspContext _context;

        public CreateTeamValidator(AspContext context)
        {
            _context = context;

            // teamName must be unique in the database
            RuleFor(x => x.TeamName)
                .NotEmpty()
                .WithMessage("Team name is required.")
                .MaximumLength(30)
                .WithMessage("Team name must have a maximum of 30 characters.")
                .Must((dto, teamName) => !_context.Teams.Any(x => x.Name == teamName))
                .WithMessage("Team name must be unique.");

            // players must exist in the database and it must be 5 players and player can only be in one team
            RuleFor(x => x.Players)
                .NotEmpty()
                .WithMessage("Players are required.")
                .Must(x => x.Count == 5)
                .WithMessage("Team must have 5 players.")
                .Must(BeExistingUsers)
                .WithMessage("All players must exist in the database.")
                .Must(HaveUniquePlayers)
                .WithMessage("Each player can only be in one team.");
        }
        private bool BeExistingUsers(ICollection<Guid> players)
        {
            // Check if all GUIDs in the 'players' collection exist in the Players table
            return players.All(playerId => _context.Players.Any(p => p.Id == playerId));

        }
        private bool HaveUniquePlayers(ICollection<Guid> playerIds)
        {
            // Ensure there are no duplicate player GUIDs
            if (playerIds.Distinct().Count() != playerIds.Count)
            {
                return false;
            }

            // Retrieve players from the database matching the provided GUIDs
            var playersInDb = _context.Players.Where(p => playerIds.Contains(p.Id)).ToList();

            // Ensure all provided GUIDs exist in the database
            if (playersInDb.Count != playerIds.Count)
            {
                return false;
            }

            // Ensure none of the players are already assigned to a team
            if (playersInDb.Any(p => p.TeamId != null))
            {
                return false;
            }

            return true;
        }
    }
}
