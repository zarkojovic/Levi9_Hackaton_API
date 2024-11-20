using Application.DTO.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Teams
{
    public class GetTeamDTO
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; }
        public ICollection<GetPlayerDTO> Players { get; set; }
    }
}