using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    /// <summary>Represents the responses given to a survey question</summary>
    public class DataItem
    {
        /// <summary>The Ident of the question asked</summary>
        public string Ident { get; set; }

        /// <summary>Set of responses given to this question</summary>
        public List<DataItemValue> Responses { get; set; } = new List<DataItemValue>();


        //To Be Discontinued:
        public List<string> Values { get; set; } = new List<string>();
        public List<LoopedDataItem> LoopedDataItems { get; set; }
    }
}
