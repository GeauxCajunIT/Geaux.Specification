// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Builder;

/// <summary>
/// Provides a builder for specifications that support caching.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class CacheSpecificationBuilder<T> : ICacheSpecificationBuilder<T> where T : class
{
    /// <summary>
    /// 
    /// </summary>
    public Specification<T> Specification { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsChainDiscarded { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    public CacheSpecificationBuilder(Specification<T> specification)
        : this(specification, false)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="specification"></param>
    /// <param name="isChainDiscarded"></param>
    public CacheSpecificationBuilder(Specification<T> specification, bool isChainDiscarded)
    {
        Specification = specification;
        IsChainDiscarded = isChainDiscarded;
    }
}

