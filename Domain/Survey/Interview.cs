using System.Collections.Generic;

namespace Domain.Survey
{
    public class Interview
    {
        public string Ident { get; set; }
        public List<DataItem> DataItems { get; set; }
        public List<HierarchicalInterview> HierarchicalInterviews { get; set; }
    }
}
