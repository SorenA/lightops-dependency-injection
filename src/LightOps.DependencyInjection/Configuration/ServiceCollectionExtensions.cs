using System;
using Microsoft.Extensions.DependencyInjection;

namespace LightOps.DependencyInjection.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLightOpsDependencyInjection(this IServiceCollection services, Action<IDependencyInjectionRootComponent> componentConfig = null)
        {
            var component = new DependencyInjectionRootComponent();

            // Invoke config delegate
            componentConfig?.Invoke(component);

            // Attach self as component
            component.AttachComponent(component);

            // Register components in service container
            foreach (var attachedComponent in component.AttachedComponents)
            {
                // Register service registrations in component
                foreach (var serviceRegistration in attachedComponent.GetServiceRegistrations())
                {
                    // Convert to ServiceDescriptor and register
                    services.Add(serviceRegistration.ToServiceDescriptor());
                }
            }

            return services;
        }
    }
}