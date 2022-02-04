using System;

namespace Core.ClassicPattern;

public interface IPolicyState
{
    void Open(DateTime? writtenDate = null);
    void Void();
    void Update();
    void Close(DateTime closedDate);
    void Cancel();
}
