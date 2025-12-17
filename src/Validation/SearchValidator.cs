// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Validation;

public class SearchValidator : IValidator
{
    private SearchValidator() { }
    public static SearchValidator Instance { get; } = new SearchValidator();

    public bool IsValid<T>(T entity, ISpecification<T> specification)
    {
        foreach (IGrouping<int, SearchExpressionInfo<T>> searchGroup in specification.SearchCriterias.GroupBy(x => x.SearchGroup))
        {
            if (searchGroup.Any(c => c.SelectorFunc(entity).Like(c.SearchTerm)) == false) return false;
        }

        return true;
    }
}

