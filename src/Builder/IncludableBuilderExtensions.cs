// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using System.Linq.Expressions;

namespace Geaux.Specification.Builder;

/// <summary>
/// Provides helper methods for chaining include expressions in specifications.
/// </summary>
public static class IncludableBuilderExtensions
{
    /// <summary>
    /// Adds a subsequent include expression when building navigation chains.
    /// </summary>
    /// <typeparam name="TEntity">The root entity type.</typeparam>
    /// <typeparam name="TPreviousProperty">The previous navigation property type.</typeparam>
    /// <typeparam name="TProperty">The navigation property type being included.</typeparam>
    /// <param name="previousBuilder">The builder representing the current include chain.</param>
    /// <param name="thenIncludeExpression">The include expression to apply.</param>
    /// <returns>An includable builder for further chaining.</returns>
    public static IIncludableSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecificationBuilder<TEntity, TPreviousProperty> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression)
        where TEntity : class
        => ThenInclude(previousBuilder, thenIncludeExpression, true);

    /// <summary>
    /// Conditionally adds a subsequent include expression when building navigation chains.
    /// </summary>
    /// <typeparam name="TEntity">The root entity type.</typeparam>
    /// <typeparam name="TPreviousProperty">The previous navigation property type.</typeparam>
    /// <typeparam name="TProperty">The navigation property type being included.</typeparam>
    /// <param name="previousBuilder">The builder representing the current include chain.</param>
    /// <param name="thenIncludeExpression">The include expression to apply.</param>
    /// <param name="condition">Whether the include expression should be added.</param>
    /// <returns>An includable builder for further chaining.</returns>
    public static IIncludableSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecificationBuilder<TEntity, TPreviousProperty> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression,
        bool condition)
        where TEntity : class
    {
        if (condition && !previousBuilder.IsChainDiscarded)
        {
            IncludeExpressionInfo info = new IncludeExpressionInfo(thenIncludeExpression, typeof(TEntity), typeof(TProperty), typeof(TPreviousProperty));

            ((List<IncludeExpressionInfo>)previousBuilder.Specification.IncludeExpressions).Add(info);
        }

        IncludableSpecificationBuilder<TEntity, TProperty> includeBuilder = new IncludableSpecificationBuilder<TEntity, TProperty>(previousBuilder.Specification, !condition || previousBuilder.IsChainDiscarded);

        return includeBuilder;
    }

    /// <summary>
    /// Adds a subsequent include expression for enumerable navigation properties.
    /// </summary>
    /// <typeparam name="TEntity">The root entity type.</typeparam>
    /// <typeparam name="TPreviousProperty">The previous enumerable navigation property type.</typeparam>
    /// <typeparam name="TProperty">The navigation property type being included.</typeparam>
    /// <param name="previousBuilder">The builder representing the current include chain.</param>
    /// <param name="thenIncludeExpression">The include expression to apply.</param>
    /// <returns>An includable builder for further chaining.</returns>
    public static IIncludableSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecificationBuilder<TEntity, IEnumerable<TPreviousProperty>> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression)
        where TEntity : class
        => ThenInclude(previousBuilder, thenIncludeExpression, true);

    /// <summary>
    /// Conditionally adds a subsequent include expression for enumerable navigation properties.
    /// </summary>
    /// <typeparam name="TEntity">The root entity type.</typeparam>
    /// <typeparam name="TPreviousProperty">The previous enumerable navigation property type.</typeparam>
    /// <typeparam name="TProperty">The navigation property type being included.</typeparam>
    /// <param name="previousBuilder">The builder representing the current include chain.</param>
    /// <param name="thenIncludeExpression">The include expression to apply.</param>
    /// <param name="condition">Whether the include expression should be added.</param>
    /// <returns>An includable builder for further chaining.</returns>
    public static IIncludableSpecificationBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecificationBuilder<TEntity, IEnumerable<TPreviousProperty>> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression,
        bool condition)
        where TEntity : class
    {
        if (condition && !previousBuilder.IsChainDiscarded)
        {
            IncludeExpressionInfo info = new IncludeExpressionInfo(thenIncludeExpression, typeof(TEntity), typeof(TProperty), typeof(IEnumerable<TPreviousProperty>));

            ((List<IncludeExpressionInfo>)previousBuilder.Specification.IncludeExpressions).Add(info);
        }

        IncludableSpecificationBuilder<TEntity, TProperty> includeBuilder = new IncludableSpecificationBuilder<TEntity, TProperty>(previousBuilder.Specification, !condition || previousBuilder.IsChainDiscarded);

        return includeBuilder;
    }
}

