using System.Collections.Generic;

namespace LightOps.DependencyInjection.Api.Providers
{
    /// <summary>
    /// Provider for the state of the attached dependency injection components
    /// </summary>
    public interface IDependencyInjectionComponentStateProvider
    {
        /// <summary>
        /// Gets a read-only list of names of the attached dependency injection components
        /// </summary>
        IReadOnlyList<string> AttachedComponentNames { get; }
    }
}