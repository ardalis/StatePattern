using Core.ClassicPattern;
using Xunit;

namespace UnitTests.PolicyTests.PolicyStateTests;

public class PolicyUnwrittenStateVoid : BasePolicyTestFixture
{
    [Fact]
    public void SetsStateToVoid()
    {
        _testUnwrittenState.Void();

        Assert.IsType<Policy.VoidState>(_testPolicy.State);
    }
}
