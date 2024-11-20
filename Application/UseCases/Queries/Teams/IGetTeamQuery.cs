using Application.DTO.Teams;
using ProjectASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Teams
{
    public interface IGetTeamQuery : IQuery<GetTeamDTO, Guid>
    {
    }
}
