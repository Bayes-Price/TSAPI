using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    public class VariableDataItem
    {
        //The response given for this variable
        public string Value { get; set; }

        //Any looped variables linked to this response
        public List<VariableData> LoopedVariableData { get; set; }
    }
}
