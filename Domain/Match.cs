using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Match : Entity
    {
        public Guid TeamOneId { get; set; }
        public Guid TeamTwoId { get; set; }
        public Guid WinningTeamId { get; set; }
        public int Duration { get; set; }
        public virtual Team TeamOne { get; set; }
        public virtual Team TeamTwo { get; set; }
        public virtual Team WinningTeam { get; set; }
    }
}
