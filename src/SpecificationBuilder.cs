// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification;

/// <summary>
/// Supports building specifications that project results into <typeparamref name="TResult"/>.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
/// <typeparam name="TResult">The projected result type.</typeparam>
public class SpecificationBuilder<T, TResult> : SpecificationBuilder<T>, ISpecificationBuilder<T, TResult>
{
    /// <summary>
    /// Gets the specification being configured.
    /// </summary>
    public new Specification<T, TResult> Specification { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpecificationBuilder{T, TResult}"/> class.
    /// </summary>
    /// <param name="specification">The underlying specification to configure.</param>
    public SpecificationBuilder(Specification<T, TResult> specification)
        : base(specification)
    {
        Specification = specification;
    }
}

/// <summary>
/// Provides a builder for configuring common specification concerns.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
public class SpecificationBuilder<T> : ISpecificationBuilder<T>
{
    /// <summary>
    /// Gets the specification being configured.
    /// </summary>
    public Specification<T> Specification { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpecificationBuilder{T}"/> class.
    /// </summary>
    /// <param name="specification">The underlying specification to configure.</param>
    public SpecificationBuilder(Specification<T> specification)
    {
        Specification = specification;
    }
}

