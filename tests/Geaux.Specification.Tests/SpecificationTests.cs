using Xunit;

namespace Geaux.Specification.Tests
{
    public class SpecificationTests
    {
        private class ActiveOrderSpec : Specification<Order>
        {
            public ActiveOrderSpec()
            {
                Query.Where(o => !o.IsDeleted)
                     .OrderBy(o => o.CreatedOn)
                     .Skip(1)
                     .Take(10);
            }
        }

        private class Order
        {
            public int Id { get; set; }
            public DateTime CreatedOn { get; set; }
            public bool IsDeleted { get; set; }
        }

        [Fact]
        public void Specification_ShouldContain_FiltersAndOrdering()
        {
            ActiveOrderSpec spec = new ActiveOrderSpec();

            Assert.NotEmpty(spec.WhereExpressions);
            Assert.NotEmpty(spec.OrderExpressions);
            Assert.Equal(1, spec.Skip);
            Assert.Equal(10, spec.Take);
        }
    }
}
