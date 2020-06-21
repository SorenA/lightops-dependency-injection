using System.Collections.Generic;
using LightOps.DependencyInjection.Api.Providers;

namespace LightOps.DependencyInjection.Domain.Providers
{
    public class DependencyInjectionComponentStateProvider : IDependencyInjectionComponentStateProvider
    {
        private readonly List<string> _attachedComponentNames;

        public DependencyInjectionComponentStateProvider(List<string> attachedComponentNames)
        {
            _attachedComponentNames = attachedComponentNames;
        }

        public IReadOnlyList<string> AttachedComponentNames => _attachedComponentNames.AsReadOnly();
    }
}