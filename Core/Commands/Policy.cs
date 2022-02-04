using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Core.Commands;

/// <summary>
/// Classic State pattern requires unique methods totalling Nodes * PossibleCommands
/// For this Policy there are 5 nodes, 5 possible commands, for 25 methods
/// Using commands we will write more classes, but fewer overall methods
/// </summary>
public class Policy
{
    static Policy()
    {
        // static registration with PolicyTransitionTable wasn't happening without this
        // TODO: Move to separate partial class
        RuntimeHelpers.RunClassConstructor(typeof(UnwrittenToOpenTransition).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(UnwrittenToVoidTransition).TypeHandle);
    }
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

    public PolicyState State { get; private set; } = PolicyState.Unwritten;
    
    private static PolicyTransitionTable ValidTransitions = new();

    public void UpdateState(PolicyCommand command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        ValidTransitions.ExecuteCommand(command, this);

    }

    // TODO: Move to partial class
    private class UnwrittenToOpenTransition : PolicyTransition
    {
        static UnwrittenToOpenTransition()
        {
            // register as a valid operation
            ValidTransitions.Add(PolicyState.Unwritten, new UnwrittenToOpenTransition());
        }

        public UnwrittenToOpenTransition() : base(PolicyState.Unwritten, PolicyCommand.OpenCommand)
        {
        }

        public override void Execute(Policy policy, PolicyCommand command)
        {
            base.Execute(policy, command);

            if (command is PolicyCommand.PolicyOpenCommand actualCommand)
            {
                policy.State = PolicyState.Open;
                policy.DateOpened = actualCommand.DateOpened;
            }
        }
    }

    // TODO: Move to partial class
    private class UnwrittenToVoidTransition : PolicyTransition
    {
        static UnwrittenToVoidTransition()
        {
            // register as a valid operation
            ValidTransitions.Add(PolicyState.Unwritten, new UnwrittenToVoidTransition());
        }

        public UnwrittenToVoidTransition() : base(PolicyState.Unwritten, PolicyCommand.VoidCommand)
        {
        }

        public override void Execute(Policy policy, PolicyCommand command)
        {
            base.Execute(policy, command);

            if (command is PolicyCommand.PolicyOpenCommand actualCommand)
            {
                policy.State = PolicyState.Void;
            }
        }
    }
}

public class PolicyTransitionTable : Dictionary<PolicyState, PolicyTransition>
{
    public bool IsValidCommand(PolicyState currentState, PolicyCommand command)
    {
        if (this.ContainsKey(currentState))
        {
            if (this[currentState] != null)
            {
                return true;
            }
        }
        return false;
    }

    public void ExecuteCommand(PolicyCommand command, Policy policy)
    {
        if (!IsValidCommand(policy.State, command)) throw new InvalidOperationException();

        var transition = this[policy.State];

        transition.Execute(policy, command);
    }
}

public class PolicyState
{
    public static readonly PolicyState Unwritten = new PolicyState(1, nameof(Unwritten));
    public static readonly PolicyState Open = new PolicyState(2, nameof(Open));
    public static readonly PolicyState Void = new PolicyState(2, nameof(Void));
    public static readonly PolicyState Cancelled = new PolicyState(2, nameof(Cancelled));
    public static readonly PolicyState Closed = new PolicyState(2, nameof(Closed));

    public int Id { get; private set; }
    public string Name { get; private set; }

    public PolicyState(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Command<T> where T : Type
{
    public T Value { get; private set; } = default(T);
}

public class PolicyCommand
{
    // TODO: How to have a list of command but also have specific instance of commands with specific properties like Dates
    //public static readonly PolicyCommand Open = new PolicyCommand(nameof(Open));
    public static readonly PolicyCommand Update = new PolicyCommand(nameof(Update));
    //public static readonly PolicyCommand Void = new PolicyCommand(nameof(Void));
    public static readonly PolicyCommand Cancel = new PolicyCommand(nameof(Cancel));
    public static readonly PolicyCommand Close = new PolicyCommand(nameof(Close));

    // TODO: Finish migrating from command instances to command types
    public static readonly Type OpenCommand = typeof(PolicyOpenCommand);
    public static readonly Type VoidCommand = typeof(PolicyVoidCommand);

    public string Name { get; private set; }
    private PolicyCommand(string name)
    {
        Name = name;
    }

    public static PolicyCommand Void() => new PolicyVoidCommand();
    public class PolicyVoidCommand : PolicyCommand
    {
        public PolicyVoidCommand() : base(nameof(Void))
        {
        }
    }

    public static PolicyCommand Open(DateTime dateOpened) => new PolicyOpenCommand(dateOpened);
    public class PolicyOpenCommand : PolicyCommand
    {
        public PolicyOpenCommand(DateTime dateOpened) : base(nameof(Open))
        {
            DateOpened = dateOpened;
        }

        public DateTime DateOpened { get; }
    }
}

public class PolicyTransition
{
    public PolicyState InitialState { get; set; }
    public Type CommandType { get; set; }

    protected PolicyTransition(PolicyState initialState, Type commandType)
    {
        InitialState = initialState;
        CommandType = commandType;
    }

    // TODO: Rename to Handle?
    // Transitions are basically command handlers that operate on a policy instance
    public virtual void Execute(Policy policy, PolicyCommand command)
    {
    }
}
