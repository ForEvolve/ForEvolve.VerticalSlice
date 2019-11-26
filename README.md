# ForEvolve.VerticalSlice

Utilities to help with vertical slice architecture. This project depends on [AutoMapper](https://github.com/AutoMapper/AutoMapper), [FluentValidation](https://github.com/JeremySkinner/FluentValidation), [MediatR](https://github.com/jbogard/MediatR), and [Scrutor](https://github.com/khellang/Scrutor). The goal is to extend one or more of these open source projects with new validators, filters, etc.

![Build, Test, and Deploy master to NuGet.org](https://github.com/ForEvolve/ForEvolve.VerticalSlice/workflows/Build%2C%20Test%2C%20and%20Deploy%20master%20to%20NuGet.org/badge.svg)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/ForEvolve.VerticalSlice)](https://www.nuget.org/packages/ForEvolve.VerticalSlice)

# Getting Started

To install the prerelease package:

```bash
dotnet add package ForEvolve.VerticalSlice
```

See [NuGet.org](https://www.nuget.org/packages/ForEvolve.VerticalSlice) for more information.

## Build and Test

To build or test, simply run `dotnet` commands like:

```bash
dotnet build
dotnet test
dotnet run
# ...
```

See [.github/workflows/master.yml](.github/workflows/master.yml) for more information about the master CI build.

# Extensions

This project plans to extend one or more of the following open source project:

-   [AutoMapper](https://github.com/AutoMapper/AutoMapper)
-   [FluentValidation](https://github.com/JeremySkinner/FluentValidation)
-   [MediatR](https://github.com/jbogard/MediatR)
-   [Scrutor](https://github.com/khellang/Scrutor)

# FluentValidation

## UriValidator

Allow validating string property, making sure the value is a valid Uri.

**How to use:**

```csharp
// Any Uri
RuleFor(x => x.Path).Uri();

// Relative Uri
RuleFor(x => x.Path).Uri(UriKind.Relative);

// Absolute Uri
RuleFor(x => x.Path).Uri(UriKind.Absolute);
```

# The Plan

I plan on using this project as my central vertical slice stack toolbox.
I may, in the future, split the project into multiple smaller projects to reduce the number of dependencies and allow each one to be used independently (like load only FluentValidation extensions without adding dependencies on the other libraries).

# How to contribute?

If you would like to contribute to the Framework, first, thank you for your interest and please read [Contributing to ForEvolve open source projects](https://github.com/ForEvolve/ForEvolve-Framework/tree/master/CONTRIBUTING.md) for more information.

## Contributor Covenant Code of Conduct

Also, please read the [Contributor Covenant Code of Conduct](https://github.com/ForEvolve/ForEvolve-Framework/tree/master/CODE_OF_CONDUCT.md) that applies to all ForEvolve repositories.
