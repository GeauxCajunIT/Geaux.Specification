// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using Geaux.Specification.Core;

namespace Geaux.Specification.Abstractions;

/// <summary>
/// Provides a builder for constructing specifications that project results into <typeparamref name="TResult"/>.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
/// <typeparam name="TResult">The projection result type.</typeparam>
public interface ISpecificationBuilder<T, TResult> : ISpecificationBuilder<T>
{
    /// <summary>
    /// Gets the underlying specification being built with projection support.
    /// </summary>
    new Specification<T, TResult> Specification { get; }
}


/// <summary>
/// Provides a builder for constructing specifications for entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
public interface ISpecificationBuilder<T>
{
    /// <summary>
    /// Gets the underlying specification being built.
    /// </summary>
    Specification<T> Specification { get; }
}
