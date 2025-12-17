using Geaux.Specification.Builder;
using Geaux.Specification.Core;
using Xunit;

namespace Geaux.Specification.Tests
{
    public class CacheSpecificationBuilderTests
    {
        private class Order { }

        private class TestSpec : Specification<Order> { }

        [Fact]
        public void Builder_ShouldSet_IsChainDiscarded()
        {
            TestSpec spec = new TestSpec();
            CacheSpecificationBuilder<Order> builder = new CacheSpecificationBuilder<Order>(spec, true);

            Assert.True(builder.IsChainDiscarded);
            Assert.Equal(spec, builder.Specification);
        }
    }
}
