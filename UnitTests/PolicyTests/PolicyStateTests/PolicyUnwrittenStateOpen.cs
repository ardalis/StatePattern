using Core;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyUnwrittenStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void SetsStateToOpen()
        {
            _testUnwrittenState.Open(_policyBuilder.TEST_OPEN_DATE);

            Assert.IsType<Policy.OpenState>(_testPolicy.State);
        }

        [Fact]
        public void SetsDateOpened()
        {
            _testUnwrittenState.Open(_policyBuilder.TEST_OPEN_DATE);

            Assert.Equal(_policyBuilder.TEST_OPEN_DATE, _testPolicy.DateOpened);
        }
    }
}
