// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Abstractions;

/// <summary>
/// Validates whether an entity satisfies a given specification.
/// </summary>
public interface ISpecificationValidator
{
    /// <summary>
    /// Determines whether the specified entity satisfies the given specification.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity to validate.</param>
    /// <param name="specification">The specification to check.</param>
    /// <returns><c>true</c> if the entity satisfies the specification; otherwise, <c>false</c>.</returns>
    bool IsValid<T>(T entity, ISpecification<T> specification);
}


