namespace Geaux.Specification.Abstractions;
/// <summary>
/// Provides a builder for specifications that support include expressions.
/// </summary>
/// <typeparam name="T">The entity type being queried.</typeparam>
/// <typeparam name="TProperty">The property type being included.</typeparam>
public class IncludableSpecificationBuilder<T, TProperty> : IIncludableSpecificationBuilder<T, TProperty> where T : class
{
    /// <summary>
    /// Gets the underlying specification being built.
    /// </summary>
    public Specification<T> Specification { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the current builder chain should be discarded.
    /// </summary>
    public bool IsChainDiscarded { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncludableSpecificationBuilder{T, TProperty}"/> class.
    /// </summary>
    /// <param name="specification">The specification to build.</param>
    public IncludableSpecificationBuilder(Specification<T> specification)
        : this(specification, false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncludableSpecificationBuilder{T, TProperty}"/> class with chain discard option.
    /// </summary>
    /// <param name="specification">The specification to build.</param>
    /// <param name="isChainDiscarded">Whether the builder chain should be discarded.</param>
    public IncludableSpecificationBuilder(Specification<T> specification, bool isChainDiscarded)
    {
        Specification = specification;
        IsChainDiscarded = isChainDiscarded;
    }
}
