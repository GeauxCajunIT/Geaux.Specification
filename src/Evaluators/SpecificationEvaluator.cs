namespace Geaux.Specification.Evaluators
{
    /// <summary>
    /// Default evaluator that applies specifications to IQueryable sources.
    /// </summary>
    public class SpecificationEvaluator : ISpecificationEvaluator
    {
        public IQueryable<TResult> GetQuery<T, TResult>(
            IQueryable<T> inputQuery,
            ISpecification<T, TResult> specification) where T : class
        {
            // Apply criteria, includes, ordering, etc.
            IQueryable<T> query = GetQuery(inputQuery, (ISpecification<T>)specification);
            return query.Select(specification.Selector!);
        }

        public IQueryable<T> GetQuery<T>(
            IQueryable<T> inputQuery,
            ISpecification<T> specification,
            bool evaluateCriteriaOnly = false) where T : class
        {
            // Apply filters
            foreach (WhereExpressionInfo<T> where in specification.WhereExpressions)
            {
                inputQuery = inputQuery.Where(where.Filter);
            }

            // Apply ordering
            // Apply ordering
            foreach (OrderExpressionInfo<T> order in specification.OrderExpressions)
            {
                if (order.OrderType == OrderTypeEnum.OrderBy)
                    inputQuery = inputQuery.OrderBy(order.KeySelector);
                else if (order.OrderType == OrderTypeEnum.OrderByDescending)
                    inputQuery = inputQuery.OrderByDescending(order.KeySelector);
                else if (order.OrderType == OrderTypeEnum.ThenBy) inputQuery = ((IOrderedQueryable<T>)inputQuery).ThenBy(order.KeySelector);
                else if (order.OrderType == OrderTypeEnum.ThenByDescending) inputQuery = ((IOrderedQueryable<T>)inputQuery).ThenByDescending(order.KeySelector);
            }

            // Apply pagination
            if (specification.Skip.HasValue)
                inputQuery = inputQuery.Skip(specification.Skip.Value);
            if (specification.Take.HasValue)
                inputQuery = inputQuery.Take(specification.Take.Value);

            return inputQuery;
        }
    }
}
