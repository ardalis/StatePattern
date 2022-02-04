using System;

namespace Core.SmartEnumPattern;

public class Policy
{
    private Policy()
    {
    }

    public Policy(string policyNumber) : this()
    {
        Number = policyNumber;
    }

    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime? DateOpened { get; private set; }
    public DateTime? DateClosed { get; private set; }

    public PolicyState State { get; private set; }

    public void Cancel() => State.Cancel(this);

    public void Close(DateTime closedDate) => State.Close(this, closedDate);

    public void Open(DateTime? writtenDate = null) => State.DoOpen(this, writtenDate);

    public void Update() => State.Update(this);

    public void Void() => State.Void(this);

    // TODO: Implement logic for valid/invalid transitions inside PolicyState
}
