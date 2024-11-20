using Application.DTO.Matches;
using Application.UseCases.Commands.Matches;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validations.Match;
using Implementation.Validations.Player;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Matches
{
    public class EfCreateMatchCommand : EfUseCase, ICreateMatchCommand
    {
        private readonly AspContext _context;
        private readonly CreateMatchValidator _validator;
        public EfCreateMatchCommand(AspContext context, CreateMatchValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "CreateMatchCommand";

        public void Execute(CreateMatchDTO data)
        {
            _validator.ValidateAndThrow(data);

            var team1 = GetTeamWithPlayers(data.Team1Id);
            var team2 = GetTeamWithPlayers(data.Team2Id);

            var match = CreateMatch(data, team1, team2);
            _context.Matches.Add(match);

            double avgEloTeam1 = CalculateAverageElo(team1.Players);
            double avgEloTeam2 = CalculateAverageElo(team2.Players);

            double scoreTeam1, scoreTeam2;

            if (data.WinningTeamId != null)
            {
                scoreTeam1 = data.WinningTeamId == data.Team1Id ? 1 : 0;
                scoreTeam2 = data.WinningTeamId == data.Team2Id ? 1 : 0;
                UpdatePlayerStats(team1.Players, avgEloTeam2, data.Duration, data.WinningTeamId, scoreTeam1);
                UpdatePlayerStats(team2.Players, avgEloTeam1, data.Duration, data.WinningTeamId, scoreTeam2);
            }
            else
            {
                scoreTeam1 = 0.5;
                scoreTeam2 = 0.5;
                UpdatePlayerStats(team1.Players, avgEloTeam2, data.Duration, null, scoreTeam1);
                UpdatePlayerStats(team2.Players, avgEloTeam1, data.Duration, null, scoreTeam2);
            }

            _context.SaveChanges();
        }

        private Team GetTeamWithPlayers(Guid teamId)
        {
            return _context.Teams
                .Include(t => t.Players)
                .FirstOrDefault(t => t.Id == teamId) ?? throw new InvalidOperationException($"Team with ID {teamId} not found.");
        }

        private Match CreateMatch(CreateMatchDTO data, Team team1, Team team2)
        {
            return new Match
            {
                TeamOne = team1,
                TeamTwo = team2,
                WinningTeam = data.WinningTeamId == null ? null : _context.Teams.Find(data.WinningTeamId),
                Duration = data.Duration
            };
        }

        private double CalculateAverageElo(IEnumerable<Player> players)
        {
            return players.Average(p => p.Elo);
        }

        private void UpdatePlayerStats(IEnumerable<Player> players, double opponentAvgElo, float duration, Guid? winningTeamId, double score)
        {
            foreach (var player in players)
            {
                player.HoursPlayed += duration;

                // Update wins and losses
                if (winningTeamId != null)
                {
                    player.Wins += player.TeamId == winningTeamId ? 1 : 0;
                    player.Losses += player.TeamId != winningTeamId ? 1 : 0;
                }

                // Update Elo rating
                double expectedScore = 1 / (1 + Math.Pow(10, (opponentAvgElo - player.Elo) / 400));
                int kFactor = DetermineKFactor(player.HoursPlayed);
                player.Elo += kFactor * (score - expectedScore);

                // Save rating adjustment for transparency
                player.ratingAdjustment = kFactor;
            }
        }

        private int DetermineKFactor(double hoursPlayed)
        {
            return hoursPlayed switch
            {
                < 500 => 50,
                >= 500 and <= 999 => 40,
                >= 1000 and <= 2999 => 30,
                >= 3000 and <= 4999 => 20,
                _ => 10
            };
        }

    }
}
