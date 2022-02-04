using Core.ClassicPattern;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests;

public class PolicyOpenStateVoid : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToVoid()
    {
        _testOpenState.Void();

        Assert.IsType<Policy.VoidState>(_testPolicy.State);
    }
}
