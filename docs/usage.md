---
title: Usage
uid: Geaux.Specification.usage
---

# Usage Guide

## Define and Apply a Specification

```csharp
public class ActiveProducts : Specification<Product>
{
    public ActiveProducts()
    {
        Query.Where(p => p.IsActive)
             .OrderBy(p => p.Name)
             .Include(p => p.Category)
             .Search(p => p.Description, "%organic%")
             .Skip(10)
             .Take(20);
    }
}
```

```csharp
var products = await repository.ListAsync(new ActiveProducts());
```

## Projecting Results

```csharp
public class ProductSummary : Specification<Product, ProductDto>
{
    public ProductSummary()
    {
        Query.Where(p => p.IsActive)
             .Select(p => new ProductDto(p.Id, p.Name, p.Price))
             .PostProcessingAction = results => results.OrderBy(p => p.Price);
    }
}
```

## Applying Cache Hints

```csharp
public class CachedProducts : Specification<Product>
{
    public CachedProducts()
    {
        Query.Where(p => p.InStock)
             .EnableCache("products:in-stock")
             .AsNoTracking();
    }
}
```

## Testing Without EF Core

```csharp
var spec = new ActiveProducts();
var inMemoryResults = products.AsQueryable().WithSpecification(spec);
```

The in-memory evaluator follows the same rules as the EF Core evaluator, giving you confidence that
specifications behave consistently in production and in tests.
