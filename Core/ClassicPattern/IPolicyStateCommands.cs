using System.Collections.Generic;

namespace Core.ClassicPattern;

public interface IPolicyStateCommands : IPolicyState
{
    List<string> ListValidOperations();
}
