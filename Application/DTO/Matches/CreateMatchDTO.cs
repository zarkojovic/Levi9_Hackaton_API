using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Matches
{
    public class CreateMatchDTO
    {
        public Guid Team1Id { get; set; }
        public Guid Team2Id { get; set; }
        public Guid? WinningTeamId { get; set; }
        public int Duration { get; set; }
    }
}
