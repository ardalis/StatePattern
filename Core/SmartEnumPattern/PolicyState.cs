using Ardalis.SmartEnum;
using System;

namespace Core.SmartEnumPattern;

/// <summary>
/// Put logic for what is/isn't allowed as transitions in each method based on current name or value
/// If transition is successful, call Policy.State = Unwritten etc.
/// </summary>
public class PolicyState : SmartEnum<PolicyState>
{
    public static readonly PolicyState Unwritten = new PolicyState(nameof(Unwritten), 1);
    public static readonly PolicyState Open = new PolicyState(nameof(Open), 2);

    protected PolicyState(string name, int value) : base(name, value)
    {
    }

    public void Cancel(Policy policy)
    {
        policy.Cancel();
    }

    public void Close(Policy policy, DateTime closedDate)
    {
        policy.Close(closedDate);
    }

    // name conflicts with state of same name
    public void DoOpen(Policy policy, DateTime? writtenDate)
    {
        policy.Open(writtenDate);
    }

    public void Update(Policy policy)
    {
        policy.Update();
    }

    public void Void(Policy policy)
    {
        policy.Void();
    }
}
