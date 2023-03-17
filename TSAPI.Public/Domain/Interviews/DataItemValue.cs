using System;
using System.Collections.Generic;
using System.Text;

namespace TSAPI.Public.Domain.Interviews
{
    public class DataItemValue
    {
        /// <summary></summary>
        public string Ident { get; set; }
        public string Response { get; set; }
        public List<DataItem> LoopedDataItems { get; set; }

        public bool Selected { get; set; }
        public bool NotShown { get; set; }

    }
}
