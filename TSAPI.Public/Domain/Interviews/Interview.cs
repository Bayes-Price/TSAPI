using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    public class Interview
    {
        public string Ident { get; set; }
        public List<DataItem> DataItems { get; set; }
        public List<HierarchicalInterview> HierarchicalInterviews { get; set; }
    }
}
