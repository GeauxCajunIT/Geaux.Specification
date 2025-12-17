// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Abstractions;

/// <summary>
/// Evaluates specifications against an in-memory collection.
/// </summary>
public interface IInMemoryEvaluator
{
    /// <summary>
    /// Applies the specification to the given enumerable source.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="query">The source collection.</param>
    /// <param name="specification">The specification to apply.</param>
    /// <returns>A filtered sequence of entities.</returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> specification);
}
