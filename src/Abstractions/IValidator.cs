// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Abstractions;

public interface IValidator
{
    bool IsValid<T>(T entity, ISpecification<T> specification);
}

