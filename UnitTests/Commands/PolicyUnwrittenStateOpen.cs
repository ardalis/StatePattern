using Core.Commands;
using System;
using Xunit;

namespace UnitTests.Commands;

public class PolicyUnwrittenStateOpen
{
    private Policy _unwrittenPolicy = new Policy("test");
    private DateTime _testDate = DateTime.Today;

    [Fact]
    public void SetsStateToOpen()
    {
        _unwrittenPolicy.UpdateState(PolicyCommand.Open(_testDate));

        Assert.Equal(PolicyState.Open, _unwrittenPolicy.State);
    }

    [Fact]
    public void SetsDateOpened()
    {
        _unwrittenPolicy.UpdateState(PolicyCommand.Open(_testDate));

        Assert.Equal(_testDate, _unwrittenPolicy.DateOpened);
    }
}
