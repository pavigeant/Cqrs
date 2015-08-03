namespace Cqrs.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Default dependency injection container used if no external container is provided. This container is not meant to be performant.
    /// </summary>
    public class SimpleContainer : IContainer
    {
        static readonly IDictionary<Type, object> singletons = new Dictionary<Type, object>();

        static readonly IDictionary<Type, Type> types = new Dictionary<Type, Type>();

        public void Register<TContract, TImplementation>() => types[typeof(TContract)] = typeof(TImplementation);

        public void Register(Type contract, Type implementation) => types[contract] = implementation;

        public void RegisterSingle<TService>(TService service) => singletons[typeof(TService)] = service;

        public TContract GetInstance<TContract>() => (TContract)GetInstance(typeof(TContract));

        private object GetInstance(Type contract)
        {
            object singleton;
            if (singletons.TryGetValue(contract, out singleton))
            {
                return singleton;
            }
            else
            {
                Type implementation;
                if (types.TryGetValue(contract, out implementation))
                {
                    var constructor = implementation.GetConstructors()[0];
                    var constructorParameters = constructor.GetParameters();
                    if (constructorParameters.Length == 0)
                        return Activator.CreateInstance(implementation);

                    var parameters = new List<object>(constructorParameters.Length);
                    foreach (ParameterInfo parameterInfo in constructorParameters)
                        parameters.Add(GetInstance(parameterInfo.ParameterType));

                    return constructor.Invoke(parameters.ToArray());
                }
            }

            return null;
        }
    }
}