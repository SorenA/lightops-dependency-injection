using LightOps.DependencyInjection.Api.Providers;
using LightOps.DependencyInjection.Configuration;
using LightOps.DependencyInjection.Test.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.DependencyInjection.Test.Tests
{
    public class ComponentTests : IClassFixture<BasicComponentFixture>
    {
        [Fact]
        public void TestComponentIsAttached()
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
        public void TestComponentConfiguration_Invoked()
        {
            var services = new ServiceCollection();

            // Add component
            var invoked = false;
            services.AddLightOpsDependencyInjection(component =>
            {
                invoked = true;
            });

            var serviceProvider = services.BuildServiceProvider();

            Assert.True(invoked);
        }
    }
}