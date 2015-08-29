using System.Collections.Generic;
using System.Reflection;

namespace Cqrs.Configuration
{
    public class CqrsConfigurationSetup
    {
        internal IContainer Container { get; private set; }

        internal bool IsUsingDefaultDispatchers { get; private set; }

        internal List<Assembly> Assemblies = new List<Assembly>();

        public CqrsConfigurationSetup WithContainer(IContainer container)
        {
            Container = container;
            return this;
        }

        public void AddHandlerFromCallingAssembly()
        {
            Assemblies.Add(Assembly.GetCallingAssembly());
        }

        public CqrsConfigurationSetup UseDefaultDispatchers()
        {
            IsUsingDefaultDispatchers = true;
            return this;
        }
    }
}