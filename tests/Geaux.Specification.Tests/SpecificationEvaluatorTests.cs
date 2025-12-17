using Geaux.Specification.Builder;
using Geaux.Specification.Core;
using Geaux.Specification.Evaluators;
using Xunit;

namespace Geaux.Specification.Tests
{
    public class SpecificationEvaluatorTests
    {
        private class Order { public bool IsDeleted { get; set; } }

        private class ActiveOrderSpec : Specification<Order>
        {
            public ActiveOrderSpec()
            {
                Query.Where(o => !o.IsDeleted);
            }
        }

        [Fact]
        public void GetQuery_ShouldApplySpecification()
        {
            IQueryable<Order> orders = new[]
            {
                new Order { IsDeleted = false },
                new Order { IsDeleted = true }
            }.AsQueryable();

            ActiveOrderSpec spec = new ActiveOrderSpec();
            SpecificationEvaluator evaluator = new SpecificationEvaluator();

            List<Order> result = evaluator.GetQuery(orders, spec).ToList();

            Assert.Single(result);
            Assert.False(result[0].IsDeleted);
        }
    }
}
