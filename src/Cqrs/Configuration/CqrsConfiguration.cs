using System;
using System.Linq;

namespace Cqrs.Configuration
{
    public static class CqrsConfiguration
    {
        public static IContainer Container { get; set; }

        public static void Setup(Action<CqrsConfigurationSetup> action)
        {
            var config = new CqrsConfigurationSetup();
            action(config);

            if (!IsValid(config))
                throw Exceptions.InvalidConfigurationException();

            ApplySetup(config);
        }

        public static void Reset()
        {
            Container = null;
        }

        private static void ApplySetup(CqrsConfigurationSetup config)
        {
            Container = config.Container;
            Container.RegisterSingle(Container);

            if (config.IsUsingDefaultDispatchers)
            {
                Container.Register<IQueryDispatcher, QueryDispatcher>();
                Container.Register<ICommandDispatcher, CommandDispatcher>();
            }

            if (!config.Assemblies.Any())
                return;

            var queryHandlerType = typeof(IQueryHandler<,>);
            var commandHandlerType = typeof(ICommandHandler<>);
            var handlers = from a in config.Assemblies
                           from t in a.GetExportedTypes()
                           from i in t.GetInterfaces().Where(i => i.IsGenericType)
                           let generic = i.GetGenericTypeDefinition()
                           where generic == queryHandlerType || generic == commandHandlerType
                           select new { Implementation = t, Contract = i };

            foreach (var handler in handlers)
            {
                Container.Register(handler.Contract, handler.Implementation);
            }
        }

        private static bool IsValid(CqrsConfigurationSetup config) => config.Container != null && config.Assemblies.Any();
    }
}
