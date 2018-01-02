using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Policy
    {
        internal class VoidState : IPolicyStateCommands
        {
            private readonly Policy _policy;

            public VoidState(Policy policy)
            {
                _policy = policy;
            }

            public void Cancel() => throw new InvalidOperationException("Cannot cancel a policy that is void.");

            public void Close(DateTime closedDate) => throw new InvalidOperationException("Cannot close a policy that is void.");

            public void Open(DateTime writtenDate) => throw new InvalidOperationException("Cannot open a policy that is void.");

            public void Update() => throw new InvalidOperationException("Cannot open a policy that is void.");

            public void Void() => throw new InvalidOperationException("Cannot open a policy that is void.");

            public List<string> ListValidOperations()
            {
                return new List<string>();
            }
        }
    }
}