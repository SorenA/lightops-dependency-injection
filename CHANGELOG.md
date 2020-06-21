# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.1.1] - 2020-06-21

### Added

- Test project with unit tests and end-to-end service container registration tests

## [0.1.0] - 2020-06-21

### Added

- CHANGELOG file
- README file describing project
- Azure Pipelines based CI/CD setup
- XML documentation on interfaces
- `IDependencyInjectionComponent` interface for components
- `IDependencyInjectionComponentStateProvider` and implementation `DependencyInjectionComponentStateProvider` to observe attached components
- `IDependencyInjectionRootComponent` and implementation `DependencyInjectionRootComponent` root component
- `ServiceRegistration` configuration model
- `IServiceCollection` extension `AddLightOpsDependencyInjection` to bootstrap the root component

[unreleased]: https://github.com/SorenA/lightops-dependency-injection/compare/0.1.1...develop
[0.1.0]: https://github.com/SorenA/lightops-dependency-injection/tree/0.1.1
[0.1.0]: https://github.com/SorenA/lightops-dependency-injection/tree/0.1.0
