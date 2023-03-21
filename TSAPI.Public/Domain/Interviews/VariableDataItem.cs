using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    public class VariableDataItem
    {
        /// <summary></summary>
        public string Response { get; set; }

        //Closed-end response details
        public string Ident { get; set; }
        public bool? Selected { get; set; }
        public bool? Shown { get; set; }

        public List<VariableData> LoopedDataItems { get; set; }

    }
}
