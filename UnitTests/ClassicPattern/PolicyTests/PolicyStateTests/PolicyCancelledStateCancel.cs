using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyCancelledStateCancel : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testCancelledState.Cancel());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }

}
