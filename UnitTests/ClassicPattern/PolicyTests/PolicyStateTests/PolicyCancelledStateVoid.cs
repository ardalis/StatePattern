using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyCancelledStateVoid : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testCancelledState.Void());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
