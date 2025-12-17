using Geaux.Specification.Builder;
using Geaux.Specification.Core;
using Geaux.Specification.Evaluators; // <-- add this
using Xunit;

namespace Geaux.Specification.Tests
{
    public class InMemoryEvaluatorTests
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
        public void Evaluate_ShouldFilterEntities()
        {
            List<Order> orders = new List<Order>
            {
                new Order { IsDeleted = false },
                new Order { IsDeleted = true }
            };

            ActiveOrderSpec spec = new ActiveOrderSpec();
            InMemorySpecificationEvaluator evaluator = new InMemorySpecificationEvaluator(); // <-- use correct class

            List<Order> result = evaluator.Evaluate(orders, spec).ToList();

            Assert.Single(result);
            Assert.False(result[0].IsDeleted);
        }
    }
}
