using Application.DTO.Players;
using Application.UseCases.Queries.Players;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Players
{
    public class EfFindAllPlayersQuery : EfUseCase, IFindAllPlayersQuery
    {
        private AspContext _context;
        public EfFindAllPlayersQuery(AspContext context) : base(context)
        {
            _context = context;
        }

        public int Id => 6;

        public string Name => "FindAllPlayersQuery";

        public IEnumerable<GetPlayerDTO> Execute(object search)
        {
            // get all players
            var players = _context.Players.Select(p => new GetPlayerDTO
            {
                Id = p.Id,
                Nickname = p.Nickname,
                Wins = p.Wins,
                Losses = p.Losses,
                Elo = p.Elo,
                HoursPlayed = p.HoursPlayed,
                TeamId = p.TeamId,
                ratingAdjustment = p.ratingAdjustment
            });

            return players;
        }
    }
}
