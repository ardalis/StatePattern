using Core.ClassicPattern;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests;

public class PolicyClosedStateCancel : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToCancelled()
    {
        _testClosedState.Cancel();

        Assert.IsType<Policy.CancelledState>(_testPolicy.State);
    }
}
