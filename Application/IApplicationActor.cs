using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application
{
    public interface IApplicationActor
    {
        Guid Id { get; }
        string Nickname { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
