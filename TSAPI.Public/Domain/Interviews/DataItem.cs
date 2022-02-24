using System.Collections.Generic;
using TSAPI.Public.Domain.Metadata;

namespace TSAPI.Public.Domain.Interviews
{
    public class DataItem
    {
        public string Ident { get; set; }
        public List<string> Values { get; set; } = new List<string>();
        public List<LoopRef> LoopRefs { get; set; }
    }
}
