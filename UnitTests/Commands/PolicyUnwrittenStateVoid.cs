using Core.Commands;
using Xunit;

namespace UnitTests.Commands;

public class PolicyUnwrittenStateVoid
{
    private Policy _unwrittenPolicy = new Policy("test");

    [Fact]
    public void SetsStateToVoid()
    {
        _unwrittenPolicy.UpdateState(PolicyCommand.Void());

        Assert.Equal(PolicyState.Void, _unwrittenPolicy.State);
    }
}
