using Core;
using System;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests
{
    public class PolicyClosedStateOpen : BasePolicyTestFixture
    {
        [Fact]
        public void SetsStateToOpen()
        {
            _testClosedState.Open(DateTime.Now);

            Assert.IsType<Policy.OpenState>(_testPolicy.State);
        }

        [Fact]
        public void DoesNotChangeOpenDate()
        {
            _testClosedState.Open(DateTime.Now);

            Assert.Null(_testPolicy.DateOpened);
        }
    }
}
