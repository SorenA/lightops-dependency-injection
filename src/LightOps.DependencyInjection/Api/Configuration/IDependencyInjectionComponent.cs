using System.Collections.Generic;
using LightOps.DependencyInjection.Domain.Configuration;

namespace LightOps.DependencyInjection.Api.Configuration
{
    /// <summary>
    /// Dependency injection component for injection service registrations into the service container
    /// </summary>
    public interface IDependencyInjectionComponent
    {
        /// <summary>
        /// Gets the name of the component
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a read-only list of all service registrations in the component
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<ServiceRegistration> GetServiceRegistrations();
    }
}