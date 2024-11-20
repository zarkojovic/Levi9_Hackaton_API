using Application.DTO.Teams;
using ProjectASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Teams
{
    public interface ICreateTeamCommand : IQuery<GetTeamDTO, CreateTeamDTO>
    {
    }
}
