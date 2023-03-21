using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    /// <summary>Represents the response(s) given to a variable in the survey</summary>
    public class VariableData
    {
        /// <summary>The Ident of the variable</summary>
        public string Ident { get; set; }

        /// <summary>Set of responses given to this variable</summary>
        public List<VariableDataItem> Values { get; set; } = new List<VariableDataItem>();

        //To Be Discontinued:
        //public List<string> Values { get; set; } = new List<string>();
        //public List<LoopedDataItem> LoopedDataItems { get; set; }
    }
}
