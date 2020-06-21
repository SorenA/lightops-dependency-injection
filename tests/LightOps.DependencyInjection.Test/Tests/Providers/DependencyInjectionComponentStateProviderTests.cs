using System.Collections.Generic;
using LightOps.DependencyInjection.Domain.Providers;
using Xunit;

namespace LightOps.DependencyInjection.Test.Tests.Providers
{
    public class DependencyInjectionComponentStateProviderTests
    {
        [Fact]
        public void TestAttachedComponentNames_NotEmpty()
        {
            var attachedComponentNames = new List<string>
            {
                "module1",
                "module2",
            };
            var provider = new DependencyInjectionComponentStateProvider(attachedComponentNames);

            Assert.NotEmpty(provider.AttachedComponentNames);
        }

        [Fact]
        public void TestAttachedComponentNames_ContainsModule()
        {
            var attachedComponentNames = new List<string>
            {
                "module1",
                "module2",
            };
            var provider = new DependencyInjectionComponentStateProvider(attachedComponentNames);

            Assert.Contains(provider.AttachedComponentNames, f => f == "module1");
        }

        [Fact]
        public void TestAttachedComponentNames_DoesNotContainsModule()
        {
            var attachedComponentNames = new List<string>
            {
                "module1",
                "module2",
            };
            var provider = new DependencyInjectionComponentStateProvider(attachedComponentNames);

            Assert.DoesNotContain(provider.AttachedComponentNames, f => f == "module3");
        }
    }
}