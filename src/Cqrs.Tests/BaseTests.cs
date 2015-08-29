using Cqrs.Configuration;

namespace Cqrs.Tests
{
    public class BaseTests
    {
        protected IQueryDispatcher QueryDispatcher => CqrsConfiguration.Container.GetInstance<IQueryDispatcher>();

        protected ICommandDispatcher CommandDispatcher => CqrsConfiguration.Container.GetInstance<ICommandDispatcher>();
    }
}