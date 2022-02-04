using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyVoidStateVoid : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testVoidState.Void());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
