namespace Cqrs.Tests
{
    using System;
    using System.Threading.Tasks;
    using Configuration;
    using Xunit;

    public class HandlerTests : BaseTests
    {
        public HandlerTests()
        {
            var container = new SimpleContainer();
            CqrsConfiguration.Setup(setup => setup.Container(container).UseDefaultDispatchers().AddHandlerFromCallingAssembly());
        }

        [Fact]
        public async void MissingCommandHandler_MustThrowException()
        {
            await Assert.ThrowsAsync<HandlerNotImplementedException>(() => CommandDispatcher.Dispatch(new UnhandledCommand()));
        }

        [Fact]
        public async void MissingQueryHandler_MustThrowException()
        {
            await Assert.ThrowsAsync<HandlerNotImplementedException>(() => QueryDispatcher.Dispatch<UnhandledQuery, UnhandledResult>(new UnhandledQuery()));
        }

        [Fact]
        public async void ExistingQueryHandler_MustNotThrowException()
        {
            await QueryDispatcher.Dispatch<HandledQuery, HandledResult>(new HandledQuery());
        }
    }

    public class HandledQuery : IQuery<HandledResult>
    {
    }

    public class HandledQueryHandler : IQueryHandler<HandledQuery, HandledResult>
    {
        public Task<HandledResult> Retrieve(HandledQuery query)
        {
            return Task<HandledResult>.Factory.StartNew(() => new HandledResult());
        }
    }

    public class UnhandledCommand : ICommand
    {
    }

    public class UnhandledQuery : IQuery<UnhandledResult>
    {
    }

    public class UnhandledResult : IQueryResult
    {
    }

    public class HandledResult : IQueryResult
    {
    }
}