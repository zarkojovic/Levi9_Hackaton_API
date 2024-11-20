using Application.DTO.Players;
using Application.UseCases.Commands.Players;
using Application.UseCases.Queries.Players;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Implementation;

namespace HackatonLeviNine.Controllers
{
    [Route("players")]
    public class PlayerController : Controller
    {
        private readonly AspContext _context;
        private readonly UseCaseHandler _useCaseHandler;
        public PlayerController([FromServices] AspContext context, UseCaseHandler handler)
        {
            _context = context;
            _useCaseHandler = handler;
        }

        [HttpGet("{id}")]
        public ActionResult Details(Guid id,[FromServices] IGetPlayerQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, id));
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] CreatePlayerDTO dto, [FromServices] ICreatePlayerCommand cmd)
        {
            return Ok(_useCaseHandler.HandleQuery(cmd, dto));
        }

    }
}
