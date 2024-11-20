using Application.DTO.Players;
using ProjectASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Players
{
    public interface ICreatePlayerCommand : IQuery<GetPlayerDTO, CreatePlayerDTO>
    {
    }
}
