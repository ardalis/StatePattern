using Core;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyOpenStateClose : BasePolicyTestFixture
    {
        [Fact]
        public void SetsStateToClosed()
        {
            _testOpenState.Close(_policyBuilder.TEST_CLOSED_DATE);

            Assert.IsType<Policy.ClosedState>(_testPolicy.State);
        }

        [Fact]
        public void SetsDateClosed()
        {
            _testOpenState.Close(_policyBuilder.TEST_CLOSED_DATE);

            Assert.Equal(_policyBuilder.TEST_CLOSED_DATE, _testPolicy.DateClosed);
        }
    }
}
