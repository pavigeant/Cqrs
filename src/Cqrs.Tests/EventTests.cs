namespace Cqrs.Tests
{
    using Configuration;
    using Xunit;

    public class ConfigurationTests : BaseTests
    {
        public ConfigurationTests()
        {
            var container = new SimpleContainer();
            CqrsConfiguration.Setup(setup => setup.WithContainer(container).UseDefaultDispatchers().AddHandlerFromCallingAssembly());
        }

        [Fact]
        public void Test1()
        {
            
        }
    }
}