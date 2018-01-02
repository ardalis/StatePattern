using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyUnwrittenStateClose : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testUnwrittenState.Close(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
