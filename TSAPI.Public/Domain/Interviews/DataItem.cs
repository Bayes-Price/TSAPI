using System.Collections.Generic;
using TSAPI.Public.Domain.Metadata;

namespace TSAPI.Public.Domain.Interviews
{
    public class DataItem
    {
        public string Ident { get; set; }
        public List<object> Values { get; set; } = new List<object>();
        public List<LoopRef> LoopRefs { get; set; }
    }
}
