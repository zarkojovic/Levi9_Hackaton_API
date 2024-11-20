using ProjectASP.Application;

namespace HackatonLeviNine.Core
{
    public interface IExceptionLogger
    {
        Guid Log(Exception ex, IApplicationActor actor);
    }
}
