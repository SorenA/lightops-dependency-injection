using LightOps.DependencyInjection.Api.Configuration;

namespace LightOps.DependencyInjection.Configuration
{
    /// <summary>
    /// Root dependency injection component
    /// </summary>
    public interface IDependencyInjectionRootComponent
    {
        /// <summary>
        /// Attaches a component to the root component
        /// </summary>
        /// <param name="component">The component to attach</param>
        /// <returns>Returns root component for chaining</returns>
        IDependencyInjectionRootComponent AttachComponent(IDependencyInjectionComponent component);
    }
}