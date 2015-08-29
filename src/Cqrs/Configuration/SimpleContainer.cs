using System;
using System.Collections.Generic;
using System.Linq;

namespace Cqrs.Configuration
{
    /// <summary>
    /// Default dependency injection container used if no external container is provided. This container is not meant to be performant.
    /// </summary>
    public class SimpleContainer : IContainer
    {
        private readonly IDictionary<Type, object> _singletons = new Dictionary<Type, object>();

        private readonly IDictionary<Type, Type> _types = new Dictionary<Type, Type>();

        public void Register<TContract, TImplementation>() => _types[typeof(TContract)] = typeof(TImplementation);

        public void Register(Type contract, Type implementation) => _types[contract] = implementation;

        public void RegisterSingle<TService>(TService service) => _singletons[typeof(TService)] = service;

        public TContract GetInstance<TContract>() => (TContract)GetInstance(typeof(TContract));

        private object GetInstance(Type contract)
        {
            object singleton;
            if (_singletons.TryGetValue(contract, out singleton))
                return singleton;

            Type implementation;
            if (!_types.TryGetValue(contract, out implementation))
                return null;

            var constructor = implementation.GetConstructors()[0];
            var constructorParameters = constructor.GetParameters();

            return constructorParameters.Length == 0 ? 
                Activator.CreateInstance(implementation) : 
                constructor.Invoke(constructorParameters.Select(parameterInfo => GetInstance(parameterInfo.ParameterType)).ToArray());
        }
    }
}