

using Application.UseCases.Commands.Matches;
using Application.UseCases.Commands.Players;
using Application.UseCases.Commands.Teams;
using Application.UseCases.Queries.Players;
using Application.UseCases.Queries.Teams;
using Implementation.UseCases.Commands.Matches;
using Implementation.UseCases.Commands.Players;
using Implementation.UseCases.Commands.Teams;
using Implementation.UseCases.Queries.Players;
using Implementation.UseCases.Queries.Teams;
using Implementation.Validations.Match;
using Implementation.Validations.Player;
using Implementation.Validations.Team;

namespace ProjectASP.API.Core
{
    public static class ExtentionMethods
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateMatchCommand, EfCreateMatchCommand>();
            services.AddTransient<ICreatePlayerCommand, EfCreatePlayerCommand>();
            services.AddTransient<ICreateTeamCommand, EfCreateTeamCommand>();
            services.AddTransient<IGetPlayerQuery, EfGetPlayerQuery>();
            services.AddTransient<IFindAllPlayersQuery, EfFindAllPlayersQuery>();
            services.AddTransient<IGetTeamQuery, EfGetTeamQuery>();
            services.AddTransient<CreatePlayerValidator>();
            services.AddTransient<GetPlayerValidator>();
            services.AddTransient<CreateTeamValidator>();
            services.AddTransient<GetTeamValidator>();
            services.AddTransient<CreateMatchValidator>();
        }
    }
}
