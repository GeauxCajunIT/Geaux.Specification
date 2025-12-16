// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using System.Linq;

namespace Geaux.Specification.Abstractions;

/// <summary>
/// Evaluates specifications against an <see cref="IQueryable{T}"/> source.
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// Gets a value indicating whether this evaluator only applies criteria (filters).
    /// </summary>
    bool IsCriteriaEvaluator { get; }

    /// <summary>
    /// Applies the specification to the given query.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="query">The source query.</param>
    /// <param name="specification">The specification to apply.</param>
    /// <returns>A filtered <see cref="IQueryable{T}"/>.</returns>
    IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class;
}
