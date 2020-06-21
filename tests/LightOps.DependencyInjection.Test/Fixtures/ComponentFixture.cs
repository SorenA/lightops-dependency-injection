using LightOps.DependencyInjection.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LightOps.DependencyInjection.Test.Fixtures
{
    public class BasicComponentFixture
    {
        public ServiceProvider ServiceProvider { get; }

        public BasicComponentFixture()
        {
            var services = new ServiceCollection();

            // Add dependency injection component
            services.AddLightOpsDependencyInjection();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}