using Application.DTO.Players;
using Application.DTO.Teams;
using Application.UseCases.Queries.Players;
using Application.UseCases.Queries.Teams;
using DataAccess;
using FluentValidation;
using Implementation.Validations.Player;
using Implementation.Validations.Team;
using Microsoft.EntityFrameworkCore;
using ProjectASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Teams
{
    public class EfGetTeamQuery : EfUseCase, IGetTeamQuery
    {
        private readonly AspContext _context;
        private readonly GetTeamValidator _validator;
        public EfGetTeamQuery(AspContext context, GetTeamValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "GetTeamQuery";

        GetTeamDTO IQuery<GetTeamDTO, Guid>.Execute(Guid search)
        {
            _validator.ValidateAndThrow(search);

            var team = _context.Teams
                .Include(t => t.Players)
                .FirstOrDefault(t => t.Id == search);

            return new GetTeamDTO
            {
                Id = team.Id,
                TeamName = team.Name,
                Players = team.Players.Select(p => new GetPlayerDTO
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
