using Application.DTO.Players;
using Application.DTO.Teams;
using Application.UseCases.Commands.Players;
using Application.UseCases.Commands.Teams;
using Application.UseCases.Queries.Players;
using Application.UseCases.Queries.Teams;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Implementation;

namespace HackatonLeviNine.Controllers
{
    [Route("teams")]
    public class TeamController : Controller
    {

        private readonly AspContext _context;
        private readonly UseCaseHandler _useCaseHandler;
        public TeamController([FromServices] AspContext context, UseCaseHandler handler)
        {
            _context = context;
            _useCaseHandler = handler;
        }

        [HttpGet("{id}")]
        public ActionResult Details(Guid id, [FromServices] IGetTeamQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, id));
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateTeamDTO dto, [FromServices] ICreateTeamCommand cmd)
        {
            return Ok(_useCaseHandler.HandleQuery(cmd, dto));
        }

    }
}
