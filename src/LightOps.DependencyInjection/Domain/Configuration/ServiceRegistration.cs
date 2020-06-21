using System;
using Microsoft.Extensions.DependencyInjection;

namespace LightOps.DependencyInjection.Domain.Configuration
{
    /// <summary>
    /// Service registration for injection into the service container
    /// </summary>
    public class ServiceRegistration
    {
        /// <summary>
        /// Gets the type of service to register in the service container
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// Gets or sets the type of implementation to register in the service container
        /// </summary>
        public Type ImplementationType { get; set; }

        /// <summary>
        /// Gets or sets the instance of implementation to register in the service container, only applicable with ServiceLifetime.Singleton
        /// </summary>
        public object ImplementationInstance { get; set; }

        /// <summary>
        /// Gets or sets the lifetime of the service
        /// </summary>
        public ServiceLifetime Lifetime { get; set; }

        public ServiceRegistration(Type serviceType)
        {
            ServiceType = serviceType;
        }
        
        public ServiceDescriptor ToServiceDescriptor()
        {
            return ImplementationType != null
                ? ServiceDescriptor.Describe(ServiceType, ImplementationType, Lifetime)
                : ServiceDescriptor.Describe(ServiceType, provider => ImplementationInstance, Lifetime);
        }

        /// <summary>
        /// Creates a new ServiceRegistration with transient lifetime
        /// </summary>
        /// <typeparam name="TService">The type of the service to register</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to register</typeparam>
        /// <returns>Returns the service registration created</returns>
        public static ServiceRegistration Transient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return new ServiceRegistration(typeof(TService))
            {
                ImplementationType = typeof(TImplementation),
                ImplementationInstance = null,
                Lifetime = ServiceLifetime.Transient,
            };
        }

        /// <summary>
        /// Creates a new ServiceRegistration with transient lifetime without a registered implementation
        /// </summary>
        /// <typeparam name="TService">The type of the service to register</typeparam>
        /// <returns>Returns the service registration created</returns>
        public static ServiceRegistration Transient<TService>()
            where TService : class
        {
            return new ServiceRegistration(typeof(TService))
            {
                ImplementationType = null,
                ImplementationInstance = null,
                Lifetime = ServiceLifetime.Transient,
            };
        }

        /// <summary>
        /// Creates a new ServiceRegistration with scoped lifetime
        /// </summary>
        /// <typeparam name="TService">The type of the service to register</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to register</typeparam>
        /// <returns>Returns the service registration created</returns>
        public static ServiceRegistration Scoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return new ServiceRegistration(typeof(TService))
            {
                ImplementationType = typeof(TImplementation),
                ImplementationInstance = null,
                Lifetime = ServiceLifetime.Scoped,
            };
        }

        /// <summary>
        /// Creates a new ServiceRegistration with transient lifetime without a registered implementation
        /// </summary>
        /// <typeparam name="TService">The type of the service to register</typeparam>
        /// <returns>Returns the service registration created</returns>
        public static ServiceRegistration Scoped<TService>()
            where TService : class
        {
            return new ServiceRegistration(typeof(TService))
            {
                ImplementationType = null,
                ImplementationInstance = null,
                Lifetime = ServiceLifetime.Scoped,
            };
        }

        /// <summary>
        /// Creates a new ServiceRegistration with singleton lifetime
        /// </summary>
        /// <typeparam name="TService">The type of the service to register</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to register</typeparam>
        /// <returns>Returns the service registration created</returns>
        public static ServiceRegistration Singleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return new ServiceRegistration(typeof(TService))
            {
                ImplementationType = typeof(TImplementation),
                ImplementationInstance = null,
                Lifetime = ServiceLifetime.Singleton,
            };
        }

        /// <summary>
        /// Creates a new ServiceRegistration with singleton lifetime with an instance of an implementation to register
        /// </summary>
        /// <typeparam name="TService">The type of the service to register</typeparam>
        /// <param name="implementationInstance">The instance of the implementation to register</param>
        /// <returns>Returns the service registration created</returns>
        public static ServiceRegistration Singleton<TService>(TService implementationInstance)
            where TService : class
        {
            return new ServiceRegistration(typeof(TService))
            {
                ImplementationType = null,
                ImplementationInstance = implementationInstance,
                Lifetime = ServiceLifetime.Singleton,
            };
        }

        /// <summary>
        /// Creates a new ServiceRegistration with singleton lifetime without a registered implementation
        /// </summary>
        /// <typeparam name="TService">The type of the service to register</typeparam>
        /// <returns>Returns the service registration created</returns>
        public static ServiceRegistration Singleton<TService>()
            where TService : class
        {
            return new ServiceRegistration(typeof(TService))
            {
                ImplementationType = null,
                ImplementationInstance = null,
                Lifetime = ServiceLifetime.Singleton,
            };
        }
    }
}