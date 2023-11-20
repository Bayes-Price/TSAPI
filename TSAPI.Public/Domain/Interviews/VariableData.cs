using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    /// <summary>Represents the response(s) given to a variable in the survey</summary>
    public class VariableData
    {
        /// <summary>The Id of the variable to which a set of variable data relates to</summary>
        public string VariableId { get; set; }

        /// <summary>List of responses given for this variable</summary>
        public List<VariableDataItem> Data { get; set; } = new List<VariableDataItem>();
       
    }
}
