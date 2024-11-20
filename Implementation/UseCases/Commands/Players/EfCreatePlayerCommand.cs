using Application.DTO.Players;
using Application.UseCases.Commands.Players;
using DataAccess;
using FluentValidation;
using Implementation.Validations.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Implementation.UseCases.Commands.Players
{
    public class EfCreatePlayerCommand : EfUseCase, ICreatePlayerCommand
    {

        private readonly AspContext _context;
        private readonly CreatePlayerValidator _validator;
        public EfCreatePlayerCommand(AspContext context, CreatePlayerValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "CreatePlayerCommand";

        public GetPlayerDTO Execute(CreatePlayerDTO data)
        {

            _validator.ValidateAndThrow(data);
            var player = new Domain.Player
            {
                Nickname = data.Nickname
            };
            _context.Players.Add(player);
            _context.SaveChanges();

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
