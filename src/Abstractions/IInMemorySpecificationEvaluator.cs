// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using System.Collections.Generic;

namespace Geaux.Specification.Abstractions;

/// <summary>
/// Evaluates specifications against in-memory collections with projection support.
/// </summary>
public interface IInMemorySpecificationEvaluator
{
    /// <summary>
    /// Applies the specification to the given source and projects the result.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TResult">The projection result type.</typeparam>
    /// <param name="source">The source collection.</param>
    /// <param name="specification">The specification to apply.</param>
    /// <returns>A filtered and projected sequence.</returns>
    IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> source, ISpecification<T, TResult> specification);

    /// <summary>
    /// Applies the specification to the given source.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="source">The source collection.</param>
    /// <param name="specification">The specification to apply.</param>
    /// <returns>A filtered sequence of entities.</returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> specification);
}
