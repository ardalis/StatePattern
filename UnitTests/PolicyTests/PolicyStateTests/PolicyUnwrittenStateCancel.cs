using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyUnwrittenStateCancel : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testUnwrittenState.Cancel());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }

}
