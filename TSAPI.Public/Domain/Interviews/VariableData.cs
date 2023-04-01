using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    /// <summary>Represents the response(s) given to a variable in the survey</summary>
    public class VariableData
    {
        /// <summary>The Ident of the variable</summary>
        public string Ident { get; set; }

        /// <summary>(For closed-end variables) Provides information about the options used for this variable in the current interview</summary>
        public List<VariableValue> ResponseMetadata { get; set; }

        /// <summary>List of responses given for this variable</summary>
        public List<VariableDataItem> Data { get; set; } = new List<VariableDataItem>();
       
    }

    /// <summary>Contains data about the closed-end responses used for a given variable and interview</summary>
    public class VariableValue
    {
        /// <summary>Id of a closed end response (refers to Metadata.VariableValues.Ident)</summary>
        public string Ident { get; set; }
        /// <summary>Flag indicating whether this response was shown for a given interview</summary>
        public bool Shown { get; set; }
    }
}
