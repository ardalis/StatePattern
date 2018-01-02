using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyCancelledStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testCancelledState.Open(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
