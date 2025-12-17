// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Validation;

public class WhereValidator : IValidator
{
    private WhereValidator() { }
    public static WhereValidator Instance { get; } = new WhereValidator();

    public bool IsValid<T>(T entity, ISpecification<T> specification)
    {
        foreach (WhereExpressionInfo<T> info in specification.WhereExpressions)
        {
            if (info.FilterFunc(entity) == false) return false;
        }

        return true;
    }
}

