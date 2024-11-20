using Application.DTO.Matches;
using Application.DTO.Players;
using Application.UseCases.Commands.Matches;
using Application.UseCases.Commands.Players;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Implementation;

namespace HackatonLeviNine.Controllers
{
    [Route("matches")]
    public class MatchController : Controller
    {
        private readonly AspContext _context;
        private readonly UseCaseHandler _useCaseHandler;
        public MatchController([FromServices] AspContext context, UseCaseHandler handler)
        {
            _context = context;
            _useCaseHandler = handler;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateMatchDTO dto, [FromServices] ICreateMatchCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return Ok();
        }

    }
}
