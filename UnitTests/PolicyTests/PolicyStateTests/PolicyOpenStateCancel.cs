using Core;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyOpenStateCancel : BasePolicyTestFixture
    {
        [Fact]
        public void ThrowsException()
        {
            _testOpenState.Cancel();

            Assert.IsType<Policy.CancelledState>(_testPolicy.State);
        }
    }
}
