using ProjectASP.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation
{

    public class Actor : IApplicationActor
    {
        public Guid Id { get; set; }

        public string Nickname { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }

    }

    public class UnauthorizedActor : IApplicationActor
    {
        public Guid Id => Guid.NewGuid();

        public string Nickname => "unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1,2, 3,4,5 };

    }
}
