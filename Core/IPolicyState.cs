using System;
using System.Collections.Generic;

namespace Core
{
    public interface IPolicyState
    {
        void Open(DateTime? writtenDate = null);
        void Void();
        void Update();
        void Close(DateTime closedDate);
        void Cancel();
    }

    public interface IPolicyStateCommands : IPolicyState
    {
        List<string> ListValidOperations();
    }
}
