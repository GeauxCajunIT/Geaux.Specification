---
title: Geaux.Specification
uid: Geaux.Specification.index
---

# **Geaux.Specification**

A powerful, lightweight implementation of the **Specification Pattern** for .NET 8+ and Entity Framework Core.

`Geaux.Specification` enables you to express filtering, sorting, eager-loading, searching, and pagination logic as **reusable, composable, testable specifications**.
This package is framework-agnostic and works with any ORM or in-memory data source.

An optional companion package — **`Geaux.Specification.EntityFrameworkCore`** — provides EF Core query translation support.

---

## **✨ Features**

* 🧠 Encapsulate query logic into reusable specification classes
* 🧩 Composable criteria (Where, OrderBy, Include, Search, Pagination, etc.)
* 🔧 Specification Builders for fluent construction
* 🛠 Evaluators for applying specifications to query sources
* 📦 Optional EF Core integration for `IQueryable<T>`
* 🚀 Highly optimized & unit-test-friendly
* 🧪 In-memory evaluator for testing
* ♻ Clean Architecture–friendly & repository-compatible

---

## **📦 Installation**

### Base Specification Library

```bash
dotnet add package Geaux.Specification
```

### EF Core Integration (optional)

```bash
dotnet add package Geaux.Specification.EntityFrameworkCore
```

---

# **🚀 Getting Started**

## Define a Specification

```csharp
public class ProductsByCategory : Specification<Product>
{
    public ProductsByCategory(int categoryId)
    {
        Query.Where(p => p.CategoryId == categoryId)
             .Include(p => p.Category)
             .OrderBy(p => p.Name);
    }
}
```

## Use It With a Repository

```csharp
var spec = new ProductsByCategory(14);
var products = await repository.ListAsync(spec);
```

If using EF Core, ensure the EF evaluator is registered.

---

# **🧩 Core Concepts**

The library is divided into composable pieces:

---

## **ISpecification<T>**

Defines all query components:

* Criteria (Where)
* Includes
* Sorting (OrderBy, OrderByDescending)
* Pagination (Skip, Take)
* Search patterns
* Caching hints

---

## **Specification<T>**

The base class used to build specifications.

Key property:

```csharp
protected SpecificationBuilder<T> Query { get; }
```

Use `.Query` to define:

```csharp
Query.Where(x => x.Active)
     .Include(x => x.Items)
     .OrderBy(x => x.CreatedOn)
     .Skip(10)
     .Take(20);
```

---

## **SpecificationBuilder<T>**

Fluent builder that captures all query components.

Supported operations:

* `Where`
* `OrderBy`, `ThenBy`
* `Include`, `ThenInclude`
* `Search`
* `Skip`, `Take`
* `AsNoTracking`
* `EnableCache`

---

# **🧰 Evaluators**

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
Evaluators apply specifications to query sources.

---

## **ISpecificationEvaluator**

Applies specifications to EF Core `IQueryable<T>`:

```csharp
var query = dbContext.Products.AsQueryable();
var result = EFSpecificationEvaluator.Default.GetQuery(query, spec);
```

Used internally by most repository implementations.

---

## **IInMemorySpecificationEvaluator**

Used for **unit testing** without EF Core:

```csharp
var result = list.AsQueryable().WithSpecification(spec);
```

Ensures your specifications behave consistently in memory and against EF Core.

---

# **🔍 Search Support**

The library includes a powerful search evaluator:

```csharp
Query.Search(x => x.Name, "coffee");
Query.Search(x => x.Description, "%organic%");
```

Supports:

* SQL-like patterns
* Multi-field search
* Composable search expressions

---

# **📄 Pagination**

Easy to express:

```csharp
Query.Skip(20).Take(10);
```

EF Core and in-memory evaluators both honor pagination.

---

# **📚 Includes (Eager Loading)**

Supports navigation properties:

```csharp
Query.Include(p => p.Category)
     .Include(p => p.Reviews);
```

Works seamlessly with:

* EF Core
* In-memory evaluation (ignored but validated)

---

# **🔧 Builder Extensions**

Extension methods provide additional helpers:

* `OrderByDescending`
* `ThenByDescending`
* `Include` chaining
* `Search` overloads
* `EnableCache`

---

# **🚦 Entity Framework Core Integration**

Install:

```bash
dotnet add package Geaux.Specification.EntityFrameworkCore
```

Adds:

* `EFSpecificationEvaluator`
* EF-friendly expression processing
* Support for navigation tree building

Usage:

```csharp
var result = await dbContext.Products
    .WithSpecification(spec)
    .ToListAsync();
```

---

# **🧪 Testing With In-Memory Evaluator**

```csharp
var result = new InMemorySpecificationEvaluator()
    .Evaluate(productsList.AsQueryable(), spec);
```

Ensures business rules are tested without infrastructure dependencies.

---

# **⚙ Repository Compatibility**

`Geaux.Specification` is fully compatible with repository abstractions such as:

* `IRepository<T>`
* `IReadRepository<T>`

Example:

```csharp
public async Task<IReadOnlyList<Product>> ListProducts(ISpecification<Product> spec)
{
    return await _repo.ListAsync(spec);
}
```

---

# **📂 Project Structure**

```
Geaux.Specification/
│
├── Abstractions/
│   ├── ISpecification.cs
│   ├── ISingleResultSpecification.cs
│   ├── ISpecificationBuilder.cs
│   └── IValidator.cs
│
├── Builders/
│   ├── SpecificationBuilder.cs
│   ├── OrderedSpecificationBuilder.cs
│   ├── IncludableSpecificationBuilder.cs
│   └── CacheSpecificationBuilder.cs
│
├── Evaluators/
│   ├── WhereEvaluator.cs
│   ├── OrderEvaluator.cs
│   ├── SearchEvaluator.cs
│   ├── PaginationEvaluator.cs
│   ├── IncludeEvaluator.cs
│   └── InMemorySpecificationEvaluator.cs
│
├── Exceptions/
│   ├── DuplicateOrderChainException.cs
│   ├── DuplicateSkipException.cs
│   ├── DuplicateTakeException.cs
│   └── SelectorNotFoundException.cs
│
└── Geaux.Specification.csproj
```

---
