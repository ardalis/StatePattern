using System;
using System.Collections.Generic;

namespace Core.ClassicPattern;

public partial class Policy
{
    public class UnwrittenState : IPolicyStateCommands
    {
        private readonly Policy _policy;

        public UnwrittenState(Policy policy)
        {
            _policy = policy;
        }
        public void Cancel() => throw new InvalidOperationException("Cannot cancel a policy before it's been Opened.");

        public void Close(DateTime closedDate) => throw new InvalidOperationException("Cannot close a policy before it's been Opened.");

        public void Open(DateTime? writtenDate = null)
        {
            _policy.State = _policy._openState;
            _policy.DateOpened = writtenDate;
        }

        public void Update() => throw new InvalidOperationException("Cannot update a policy before it's been Opened.");

        public void Void()
        {
            _policy.State = _policy._voidState;
        }

        public List<string> ListValidOperations()
        {
            return new List<string> { "Open", "Void" };
        }

    }
}
