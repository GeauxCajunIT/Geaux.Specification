// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using System.Linq.Expressions;

namespace Geaux.Specification.Builder;

/// <summary>
/// Provides helper methods for chaining ordering expressions.
/// </summary>
public static class OrderedBuilderExtensions
{
    /// <summary>
    /// Adds an ascending ordering to the current specification.
    /// </summary>
    /// <typeparam name="T">The entity type being ordered.</typeparam>
    /// <param name="orderedBuilder">The ordered builder to configure.</param>
    /// <param name="orderExpression">The expression describing the order.</param>
    public static IOrderedSpecificationBuilder<T> ThenBy<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression)
        => ThenBy(orderedBuilder, orderExpression, true);

    /// <summary>
    /// Conditionally adds an ascending ordering to the current specification.
    /// </summary>
    /// <typeparam name="T">The entity type being ordered.</typeparam>
    /// <param name="orderedBuilder">The ordered builder to configure.</param>
    /// <param name="orderExpression">The expression describing the order.</param>
    /// <param name="condition">Whether the order should be applied.</param>
    public static IOrderedSpecificationBuilder<T> ThenBy<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression,
        bool condition)
    {
        if (condition && !orderedBuilder.IsChainDiscarded)
        {
            ((List<OrderExpressionInfo<T>>)orderedBuilder.Specification.OrderExpressions).Add(new OrderExpressionInfo<T>(orderExpression, OrderTypeEnum.ThenBy));
        }
        else
        {
            orderedBuilder.IsChainDiscarded = true;
        }

        return orderedBuilder;
    }

    /// <summary>
    /// Adds a descending ordering to the current specification.
    /// </summary>
    /// <typeparam name="T">The entity type being ordered.</typeparam>
    /// <param name="orderedBuilder">The ordered builder to configure.</param>
    /// <param name="orderExpression">The expression describing the order.</param>
    public static IOrderedSpecificationBuilder<T> ThenByDescending<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression)
        => ThenByDescending(orderedBuilder, orderExpression, true);

    /// <summary>
    /// Conditionally adds a descending ordering to the current specification.
    /// </summary>
    /// <typeparam name="T">The entity type being ordered.</typeparam>
    /// <param name="orderedBuilder">The ordered builder to configure.</param>
    /// <param name="orderExpression">The expression describing the order.</param>
    /// <param name="condition">Whether the order should be applied.</param>
    public static IOrderedSpecificationBuilder<T> ThenByDescending<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression,
        bool condition)
    {
        if (condition && !orderedBuilder.IsChainDiscarded)
        {
            ((List<OrderExpressionInfo<T>>)orderedBuilder.Specification.OrderExpressions).Add(new OrderExpressionInfo<T>(orderExpression, OrderTypeEnum.ThenByDescending));
        }
        else
        {
            orderedBuilder.IsChainDiscarded = true;
        }

        return orderedBuilder;
    }
}

