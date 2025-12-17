using Geaux.Specification.Builder;
using Geaux.Specification.Core;
using Geaux.Specification.Validation;
using Xunit;

namespace Geaux.Specification.Tests
{
    public class ValidatorTests
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
        public void IsValid_ShouldReturnTrue_WhenEntityMatchesSpec()
        {
            ActiveOrderSpec spec = new ActiveOrderSpec();
            SpecificationValidator validator = new SpecificationValidator();

            Order order = new Order { IsDeleted = false };
            Assert.True(validator.IsValid(order, spec));
        }

        [Fact]
        public void IsValid_ShouldReturnFalse_WhenEntityDoesNotMatchSpec()
        {
            ActiveOrderSpec spec = new ActiveOrderSpec();
            SpecificationValidator validator = new SpecificationValidator();

            Order order = new Order { IsDeleted = true };
            Assert.False(validator.IsValid(order, spec));
        }
    }
}
