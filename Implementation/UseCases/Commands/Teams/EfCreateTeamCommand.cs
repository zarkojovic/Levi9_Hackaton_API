using Application.DTO.Players;
using Application.DTO.Teams;
using Application.UseCases.Commands.Teams;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validations.Team;
using ProjectASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Teams
{
    public class EfCreateTeamCommand : EfUseCase, ICreateTeamCommand
    {
        private readonly AspContext _context;
        private readonly CreateTeamValidator _validator;
        public EfCreateTeamCommand(AspContext context, CreateTeamValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "CreateTeamCommand";

        GetTeamDTO IQuery<GetTeamDTO, CreateTeamDTO>.Execute(CreateTeamDTO search)
        {
            _validator.ValidateAndThrow(search);

            // Retrieve the players from the database based on the provided GUIDs
            var players = _context.Players
                .Where(p => search.Players.Contains(p.Id))
                .ToList();

            Team team = new Team
            {
                Name = search.TeamName,
                Players = players
            };
            // Save the team to the database
            _context.Teams.Add(team);
            _context.SaveChanges();

            // Return a DTO or any other response object
            return new GetTeamDTO
            {
                Id = team.Id,
                TeamName = team.Name,
                Players = players.Select(p => new GetPlayerDTO
                {
                    Id = p.Id,
                    Nickname = p.Nickname,
                    Wins = p.Wins,
                    Losses = p.Losses,
                    Elo = p.Elo,
                    HoursPlayed = p.HoursPlayed,
                    TeamId = p.TeamId,
                    ratingAdjustment = p.ratingAdjustment
                }).ToList()
            };

        }
    }
}