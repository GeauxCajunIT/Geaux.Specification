---
title: Geaux.Specification
uid: Geaux.Specification.index
---

# Geaux.Specification

`Geaux.Specification` provides a lightweight, reusable implementation of the Specification Pattern for .NET 8+. It encapsulates query logic into composable specifications that work with both EF Core and in-memory data sets.

## Key Features

* Fluent builders for filtering, sorting, pagination, and includes
* In-memory evaluator for unit testing specifications without EF Core
* Optional EF Core integration for translating specifications to `IQueryable<T>`
* Cache hints, search helpers, and repository-friendly abstractions

## Getting Started

1. Install the base library:
   ```bash
   dotnet add package Geaux.Specification
   ```
2. (Optional) Add EF Core support:
   ```bash
   dotnet add package Geaux.Specification.EntityFrameworkCore
   ```
3. Define a specification:
   ```csharp
   public class ActiveProducts : Specification<Product>
   {
       public ActiveProducts()
       {
           Query.Where(p => p.IsActive)
                .OrderBy(p => p.Name)
                .Take(25);
       }
   }
   ```
4. Apply it through your repository or evaluator:
   ```csharp
   var products = await repository.ListAsync(new ActiveProducts());
   ```

## Additional Resources

* See the project README for a deeper tour of builders, evaluators, and architecture guidance.
* Repository: https://github.com/GeauxCajunIT/GeauxPlatform
