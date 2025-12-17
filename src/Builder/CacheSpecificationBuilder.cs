// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Builder;

/// <summary>
/// Provides a builder for specifications that support caching.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
public class CacheSpecificationBuilder<T> : ICacheSpecificationBuilder<T> where T : class
{
    /// <summary>
    /// Gets the specification being configured.
    /// </summary>
    public Specification<T> Specification { get; }

    /// <summary>
    /// Indicates whether the current builder chain should be ignored.
    /// </summary>
    public bool IsChainDiscarded { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="CacheSpecificationBuilder{T}"/> class.
    /// </summary>
    /// <param name="specification">The specification that will receive caching metadata.</param>
    public CacheSpecificationBuilder(Specification<T> specification)
        : this(specification, false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CacheSpecificationBuilder{T}"/> class with explicit discard state.
    /// </summary>
    /// <param name="specification">The specification that will receive caching metadata.</param>
    /// <param name="isChainDiscarded">Whether the current chain of cache operations should be ignored.</param>
    public CacheSpecificationBuilder(Specification<T> specification, bool isChainDiscarded)
    {
        Specification = specification;
        IsChainDiscarded = isChainDiscarded;
    }
}

