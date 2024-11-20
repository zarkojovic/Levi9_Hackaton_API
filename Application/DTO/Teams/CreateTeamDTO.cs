using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Teams
{
    public class CreateTeamDTO
    {
        public string TeamName { get; set; }
        public ICollection<Guid> Players { get; set; }
    }
}
