using System.Collections.Generic;
using System.Linq;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Api.Providers;
using LightOps.DependencyInjection.Domain.Configuration;
using LightOps.DependencyInjection.Domain.Providers;

namespace LightOps.DependencyInjection.Configuration
{
    public class DependencyInjectionRootComponent : IDependencyInjectionRootComponent, IDependencyInjectionComponent
    {
        public string Name => "lightops.dependency-injection";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            // Create component state provider instance
            var attachedComponentNames = _components
                .Select(m => m.Name)
                .ToList();
            var componentStateProvider = new DependencyInjectionComponentStateProvider(attachedComponentNames);
            _providers[Providers.DependencyInjectionComponentStateProvider].ImplementationInstance = componentStateProvider;

            return new List<ServiceRegistration>()
                .Union(_providers.Values)
                .ToList();
        }

        #region Components
        public IReadOnlyList<IDependencyInjectionComponent> AttachedComponents => _components.AsReadOnly();

        private readonly List<IDependencyInjectionComponent> _components = new List<IDependencyInjectionComponent>();

        public IDependencyInjectionRootComponent AttachComponent(IDependencyInjectionComponent component)
        {
            _components.Add(component);
            return this;
        }
        #endregion Components

        #region Providers
        internal enum Providers
        {
            DependencyInjectionComponentStateProvider,
        }

        private readonly Dictionary<Providers, ServiceRegistration> _providers = new Dictionary<Providers, ServiceRegistration>
        {
            [Providers.DependencyInjectionComponentStateProvider] = ServiceRegistration.Singleton<IDependencyInjectionComponentStateProvider>(),
        };
        #endregion Providers

    }
}