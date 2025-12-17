---
title: Features
uid: Geaux.Specification.features
---

# Feature Overview

Geaux.Specification ships with a broad set of helpers to keep queries expressive and testable.

## Fluent Query Composition

* **Filtering:** Add one or more `Where` expressions with conditional inclusion when you only want to apply some filters.
* **Sorting:** Chain `OrderBy`/`ThenBy` (or the descending variants) while controlling chain discard logic.
* **Includes:** Use `Include` and `ThenInclude` for navigation properties or raw include strings for advanced EF Core scenarios.
* **Pagination:** Combine `Skip` and `Take` to page results in both EF Core and in-memory evaluators.

## Projection & Post-Processing

* Map results with `Selector` or `SelectorMany` for projections.
* Apply `PostProcessingAction` delegates when you need to transform the materialized results.

## Tracking & Performance Controls

* Toggle change tracking with `AsNoTracking`, `AsTracking`, and `AsNoTrackingWithIdentityResolution`.
* Control server-side execution with `AsSplitQuery` and `IgnoreQueryFilters` for EF Core queries.
* Attach cache hints through `CacheEnabled` and `CacheKey` so downstream layers can cache specification results consistently.

## Evaluators

* Use `EFSpecificationEvaluator` (via the EntityFrameworkCore package) to translate specifications into `IQueryable<T>`.
* Use `InMemorySpecificationEvaluator` to validate behavior in unit tests without a database dependency.

## Validation

Specifications can validate entities through `ISpecificationValidator`, enabling guardrails such as
pre-query checks or domain rules before executing a query.
