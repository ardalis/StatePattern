using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyClosedStateVoid : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testClosedState.Void());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
