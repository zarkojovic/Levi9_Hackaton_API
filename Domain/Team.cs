using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
