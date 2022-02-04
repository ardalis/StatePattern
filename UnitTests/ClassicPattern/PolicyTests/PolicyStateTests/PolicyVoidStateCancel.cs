using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyVoidStateCancel : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            var exception = Record.Exception(() => _testVoidState.Cancel());

            Assert.IsType<InvalidOperationException>(exception);
        }
    }

}
