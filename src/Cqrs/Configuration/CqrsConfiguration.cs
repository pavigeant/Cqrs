using System;
using System.Linq;

namespace Cqrs.Configuration
{
    public static class CqrsConfiguration
    {
        public static IContainer Container { get; set; }

        public static void Setup(Action<CqrsConfigurationSetup> setup)
        {
            var config = new CqrsConfigurationSetup();
            setup(config);

            if(IsValid(config))
            {
                ApplySetup(config);
            }
        }

        private static void ApplySetup(CqrsConfigurationSetup config)
        {
            Container = config._container;
            Container.RegisterSingle(Container);

            if(config._useDefaultDispatchers)
            {
                Container.Register<IQueryDispatcher, QueryDispatcher>();
                Container.Register<ICommandDispatcher, CommandDispatcher>();
            }

            if (config._assemblies.Any())
            {
                var queryHandlerType = typeof(IQueryHandler<,>);
                var commandHandlerType = typeof(ICommandHandler<>);
                foreach (var assembly in config._assemblies)
                {
                    var handlers = from t in assembly.GetExportedTypes()
                                from i in t.GetInterfaces().Where(i => i.IsGenericType)
                                let generic = i.GetGenericTypeDefinition()
                                where generic == queryHandlerType || generic == commandHandlerType
                                select new { Implementation = t, Contract = i };

                    foreach (var handler in handlers)
                    {
                        Container.Register(handler.Contract, handler.Implementation);
                    }
                }
            }
        }

        private static bool IsValid(CqrsConfigurationSetup config)
        {
            return config._container != null;
        }
    }
}
