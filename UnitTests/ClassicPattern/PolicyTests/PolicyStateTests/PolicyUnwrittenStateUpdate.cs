using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyUnwrittenStateUpdate : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testUnwrittenState.Update());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
