using Application.DTO.Players;
using Application.UseCases.Queries.Players;
using DataAccess;
using FluentValidation;
using Implementation.Validations.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Players
{
    public class EfGetPlayerQuery : EfUseCase, IGetPlayerQuery
    {
        private readonly AspContext _context;
        private readonly GetPlayerValidator _validator;
        public EfGetPlayerQuery(AspContext context, GetPlayerValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 2;

        public string Name => "GetPlayerQuery";

        public GetPlayerDTO Execute(Guid search)
        {
            _validator.ValidateAndThrow(search);
            var player = _context.Players.Find(search);

            return new GetPlayerDTO
            {
                Id = player.Id,
                Nickname = player.Nickname,
                Wins = player.Wins,
                Losses = player.Losses,
                Elo = player.Elo,
                HoursPlayed = player.HoursPlayed,
                TeamId = player.TeamId,
                ratingAdjustment = player.ratingAdjustment
            };
        }
    }
}
