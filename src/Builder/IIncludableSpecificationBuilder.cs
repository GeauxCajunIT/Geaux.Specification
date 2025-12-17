// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Builder;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public interface IIncludableSpecificationBuilder<T, out TProperty> : ISpecificationBuilder<T> where T : class
{
    /// <summary>
    /// 
    /// </summary>
    bool IsChainDiscarded { get; set; }
}