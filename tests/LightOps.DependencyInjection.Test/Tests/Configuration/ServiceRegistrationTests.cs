using LightOps.DependencyInjection.Domain.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.DependencyInjection.Test.Tests.Configuration
{
    public class ServiceRegistrationTests
    {
        public interface IServiceRegistrationTestInterface
        {

        }

        public class ServiceRegistrationTestImpl : IServiceRegistrationTestInterface
        {

        }

        [Fact]
        public void TestServiceRegistrationTransient_Null()
        {
            var serviceRegistration = ServiceRegistration.Transient<IServiceRegistrationTestInterface>();

            Assert.Equal(typeof(IServiceRegistrationTestInterface), serviceRegistration.ServiceType);
            Assert.Equal(ServiceLifetime.Transient, serviceRegistration.Lifetime);
            Assert.Null(serviceRegistration.ImplementationInstance);
            Assert.Null(serviceRegistration.ImplementationType);
        }

        [Fact]
        public void TestServiceRegistrationTransient_Type()
        {
            var serviceRegistration = ServiceRegistration.Transient<IServiceRegistrationTestInterface, ServiceRegistrationTestImpl>();

            Assert.Equal(typeof(IServiceRegistrationTestInterface), serviceRegistration.ServiceType);
            Assert.Equal(ServiceLifetime.Transient, serviceRegistration.Lifetime);
            Assert.Null(serviceRegistration.ImplementationInstance);
            Assert.Equal(typeof(ServiceRegistrationTestImpl), serviceRegistration.ImplementationType);
        }

        [Fact]
        public void TestServiceRegistrationScoped_Null()
        {
            var serviceRegistration = ServiceRegistration.Scoped<IServiceRegistrationTestInterface>();

            Assert.Equal(typeof(IServiceRegistrationTestInterface), serviceRegistration.ServiceType);
            Assert.Equal(ServiceLifetime.Scoped, serviceRegistration.Lifetime);
            Assert.Null(serviceRegistration.ImplementationInstance);
            Assert.Null(serviceRegistration.ImplementationType);
        }

        [Fact]
        public void TestServiceRegistrationScoped_Type()
        {
            var serviceRegistration = ServiceRegistration.Scoped<IServiceRegistrationTestInterface, ServiceRegistrationTestImpl>();

            Assert.Equal(typeof(IServiceRegistrationTestInterface), serviceRegistration.ServiceType);
            Assert.Equal(ServiceLifetime.Scoped, serviceRegistration.Lifetime);
            Assert.Null(serviceRegistration.ImplementationInstance);
            Assert.Equal(typeof(ServiceRegistrationTestImpl), serviceRegistration.ImplementationType);
        }

        [Fact]
        public void TestServiceRegistrationSingleton_Null()
        {
            var serviceRegistration = ServiceRegistration.Singleton<IServiceRegistrationTestInterface>();

            Assert.Equal(typeof(IServiceRegistrationTestInterface), serviceRegistration.ServiceType);
            Assert.Equal(ServiceLifetime.Singleton, serviceRegistration.Lifetime);
            Assert.Null(serviceRegistration.ImplementationInstance);
            Assert.Null(serviceRegistration.ImplementationType);
        }

        [Fact]
        public void TestServiceRegistrationSingleton_Type()
        {
            var serviceRegistration = ServiceRegistration.Singleton<IServiceRegistrationTestInterface, ServiceRegistrationTestImpl>();

            Assert.Equal(typeof(IServiceRegistrationTestInterface), serviceRegistration.ServiceType);
            Assert.Equal(ServiceLifetime.Singleton, serviceRegistration.Lifetime);
            Assert.Null(serviceRegistration.ImplementationInstance);
            Assert.Equal(typeof(ServiceRegistrationTestImpl), serviceRegistration.ImplementationType);
        }

        [Fact]
        public void TestServiceRegistrationSingleton_Instance()
        {
            var instance = new ServiceRegistrationTestImpl();

            var serviceRegistration = ServiceRegistration.Singleton<IServiceRegistrationTestInterface>(instance);

            Assert.Equal(typeof(IServiceRegistrationTestInterface), serviceRegistration.ServiceType);
            Assert.Equal(ServiceLifetime.Singleton, serviceRegistration.Lifetime);
            Assert.NotNull(serviceRegistration.ImplementationInstance);
            Assert.Same(instance, serviceRegistration.ImplementationInstance);
            Assert.Null(serviceRegistration.ImplementationType);
        }
    }
}