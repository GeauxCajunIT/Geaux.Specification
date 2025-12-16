// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

using System.Collections.Generic;

namespace Geaux.Specification.Abstractions;

public interface IInMemorySpecificationEvaluator
{
    IEnumerable<TResult> Evaluate<T, TResult>(IEnumerable<T> source, ISpecification<T, TResult> specification);
    IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> specification);
}

