using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyVoidStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testVoidState.Open(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
