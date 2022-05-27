using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    public class DataItem
    {
        public string Ident { get; set; }
        public List<string> Values { get; set; } = new List<string>();
        public List<LoopedDataItem> LoopedDataItems { get; set; }
    }
}
