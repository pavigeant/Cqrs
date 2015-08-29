using System;

namespace Cqrs.Configuration
{
    public interface IContainer
    {
        TContract GetInstance<TContract>();

        void Register<TContract, TImplementation>();

        void Register(Type contract, Type implementation);

        void RegisterSingle<TService>(TService service);
    }
}