// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Builder;

/// <summary>
/// Tracks ordered clauses applied to a specification.
/// </summary>
/// <typeparam name="T">The entity type being ordered.</typeparam>
public class OrderedSpecificationBuilder<T> : IOrderedSpecificationBuilder<T>
{
    /// <summary>
    /// Gets the specification being configured.
    /// </summary>
    public Specification<T> Specification { get; }

    /// <summary>
    /// Indicates whether subsequent ordering operations should be skipped.
    /// </summary>
    public bool IsChainDiscarded { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderedSpecificationBuilder{T}"/> class.
    /// </summary>
    /// <param name="specification">The specification that will be ordered.</param>
    public OrderedSpecificationBuilder(Specification<T> specification)
        : this(specification, false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderedSpecificationBuilder{T}"/> class.
    /// </summary>
    /// <param name="specification">The specification that will be ordered.</param>
    /// <param name="isChainDiscarded">Whether the current ordering chain should be ignored.</param>
    public OrderedSpecificationBuilder(Specification<T> specification, bool isChainDiscarded)
    {
        Specification = specification;
        IsChainDiscarded = isChainDiscarded;
    }
}

