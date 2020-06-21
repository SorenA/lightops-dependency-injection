using LightOps.DependencyInjection.Api.Providers;
using LightOps.DependencyInjection.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.DependencyInjection.Test.Tests
{
    public class ComponentTests
    {
        [Fact]
        public void TestComponent_IsAttached()
        {
            var services = new ServiceCollection();

            // Add component
            services.AddLightOpsDependencyInjection();

            var serviceProvider = services.BuildServiceProvider();

            // Get 
            var dependencyInjectionComponentStateProvider = serviceProvider.GetService<IDependencyInjectionComponentStateProvider>();

            Assert.Contains("lightops.dependency-injection",
                dependencyInjectionComponentStateProvider.AttachedComponentNames);
        }

        [Fact]
        public void TestComponent_Configuration_Invoked()
        {
            var services = new ServiceCollection();

            // Add component
            var invoked = false;
            services.AddLightOpsDependencyInjection(root =>
            {
                invoked = true;
            });

            var serviceProvider = services.BuildServiceProvider();

            Assert.True(invoked);
        }
    }
}