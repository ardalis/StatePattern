using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Policy
    {

        public class OpenState : IPolicyStateCommands
        {
            private readonly Policy _policy;

            public OpenState(Policy policy)
            {
                _policy = policy;
            }

            public void Cancel()
            {
                _policy.State = _policy._cancelledState;
            }

            public void Close(DateTime closedDate)
            {
                _policy.State = _policy._closedState;
                _policy.DateClosed = closedDate;
            }

            public void Open(DateTime? writtenDate = null) => throw new InvalidOperationException("Cannot open a policy that is already open.");

            public void Update()
            {
                // TODO: Add update logic
            }

            public void Void()
            {
                _policy.State = _policy._voidState;
            }

            public List<string> ListValidOperations()
            {
                return new List<string> { "Cancel", "Close", "Update", "Void" };
            }
        }
    }
}