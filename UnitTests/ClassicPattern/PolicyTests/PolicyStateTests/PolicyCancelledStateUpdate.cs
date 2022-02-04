using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyCancelledStateUpdate : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testCancelledState.Update());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
