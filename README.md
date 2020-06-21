# LightOps.DependencyInjection

Dependency Injection package for .NET Standard.

![Nuget](https://img.shields.io/nuget/v/LightOps.DependencyInjection)

## Concepts

The package defines the following concepts.

### Dependency injection component interface - `IDependencyInjectionComponent`

Interface for dependency injection components containing service registrations.

### Dependency injection component state provider - `IDependencyInjectionComponentStateProvider` and implementation `DependencyInjectionComponentStateProvider`

Provider for observing the attached components.

### Dependency injection root component - `IDependencyInjectionRootComponent` and implementation `DependencyInjectionRootComponent`

Root dependency injection component that other components attach to for injection of their service registrations into the service container.

### Service registration configuration model - `ServiceRegistration`

Configuration model for defining service registrations that can be changed through component configurations.

## Attaching the component

Register during startup through the `AddLightOpsDependencyInjection` extension on `IServiceCollection`.

```csharp
// Add root component
services.AddLightOpsDependencyInjection(root =>
{
    // Register other components
    // ...
});
```

### Required component dependencies

None.
