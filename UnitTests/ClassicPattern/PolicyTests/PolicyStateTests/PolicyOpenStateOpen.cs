using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyOpenStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testOpenState.Open(DateTime.Now));

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
