using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, object> _services = new();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new Exception($"Interface {interfaceType.Name} is not implemented by {implementationType.Name}");
            }

            _services[interfaceType] = Activator.CreateInstance(implementationType);
        }

        public T Get<T>()
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                throw new Exception($"Service {typeof(T)} is not found");
            }

            return (T)_services[typeof(T)];
        }
    }
}