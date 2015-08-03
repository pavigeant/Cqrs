namespace Cqrs.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class CqrsConfigurationSetup
    {
        internal IContainer _container { get; private set; }

        internal bool _useDefaultDispatchers { get; private set; }

        internal List<Assembly> _assemblies = new List<Assembly>();

        public CqrsConfigurationSetup Container(IContainer container)
        {
            _container = container;
            return this;
        }

        public void AddHandlerFromCallingAssembly()
        {
            _assemblies.Add(Assembly.GetCallingAssembly());
        }

        public CqrsConfigurationSetup UseDefaultDispatchers()
        {
            _useDefaultDispatchers = true;
            return this;
        }
    }
}