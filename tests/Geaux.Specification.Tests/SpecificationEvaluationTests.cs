using Geaux.Specification.Core;
using Xunit;

namespace Geaux.Specification.Tests;

public class SpecificationEvaluationTests
{
    private sealed class EvenNumbersSpecification : Specification<int>
    {
        public EvenNumbersSpecification()
        {
            Query.Where(x => x % 2 == 0);
        }
    }

    [Fact]
    public void Evaluate_FiltersSequenceUsingWhereExpressions()
    {
        EvenNumbersSpecification specification = new EvenNumbersSpecification();
        var values = new[] { 1, 2, 3, 4 };

        var result = specification.Evaluate(values).ToArray();

        Assert.Equal(new[] { 2, 4 }, result);
    }
}
