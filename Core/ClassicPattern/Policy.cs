using System;

namespace Core.ClassicPattern;

public partial class Policy : IPolicyState
{
    private Policy()
    {
        _cancelledState = new CancelledState(this);
        _closedState = new ClosedState(this);
        _openState = new OpenState(this);
        _unwrittenState = new UnwrittenState(this);
        _voidState = new VoidState(this);
        State = _unwrittenState;
    }

    public Policy(string policyNumber) : this()
    {
        Number = policyNumber;
    }

    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime? DateOpened { get; private set; }
    public DateTime? DateClosed { get; private set; }

    private readonly IPolicyStateCommands _cancelledState;
    private readonly IPolicyStateCommands _closedState;
    private readonly IPolicyStateCommands _openState;
    private readonly IPolicyStateCommands _unwrittenState;
    private readonly IPolicyStateCommands _voidState;
    public IPolicyStateCommands State { get; private set; }

    public void Cancel()
    {
        State.Cancel();
    }

    public void Close(DateTime closedDate)
    {
        State.Close(closedDate);
    }

    public void Open(DateTime? writtenDate = null)
    {
        State.Open(writtenDate);
    }

    public void Update()
    {
        State.Update();
    }

    public void Void()
    {
        State.Void();
    }
}
