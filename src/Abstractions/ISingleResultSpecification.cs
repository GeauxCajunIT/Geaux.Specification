// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Abstractions;


/// <summary>
/// Encapsulates query logic for <typeparamref name="T"/>. It is meant to return a single result.
/// </summary>
/// <typeparam name="T">The type being queried against.</typeparam>
public interface ISingleResultSpecification<T> : ISpecification<T>//, ISingleResultSpecification
{
}

/// <summary>
/// Encapsulates query logic for <typeparamref name="T"/>,
/// and projects the result into <typeparamref name="TResult"/>. It is meant to return a single result.
/// </summary>
/// <typeparam name="T">The type being queried against.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
public interface ISingleResultSpecification<T, TResult> : ISpecification<T, TResult>//, ISingleResultSpecification
{
}

