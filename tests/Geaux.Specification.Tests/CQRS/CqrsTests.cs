using Geaux.SharedKernal.CQRS;
using Xunit;

namespace Geaux.Specification.Tests.CQRS
{
    /// <summary>
    /// Tests for CQRS command and query marker interfaces.
    /// </summary>
    public class CqrsTests
    {
        [Fact]
        public void ICommand_ShouldImplement_IRequest()
        {
            Type commandType = typeof(ICommand<int>);
            Assert.True(typeof(MediatR.IRequest<int>).IsAssignableFrom(commandType));
        }

        [Fact]
        public void IQuery_ShouldImplement_IRequest()
        {
            Type queryType = typeof(IQuery<string>);
            Assert.True(typeof(MediatR.IRequest<string>).IsAssignableFrom(queryType));
        }
    }
}
