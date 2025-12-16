// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Abstractions;

/// <summary>
/// Provides a builder for specifications that support ordering.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
public interface IOrderedSpecificationBuilder<T> : ISpecificationBuilder<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the current builder chain should be discarded.
    /// </summary>
    bool IsChainDiscarded { get; set; }
}
