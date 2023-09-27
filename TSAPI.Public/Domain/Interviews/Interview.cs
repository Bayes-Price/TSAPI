using System;
using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    public class Interview
    {
        public string InterviewId { get; set; }
        public DateTime Date { get; set; }
        public bool Complete { get; set; }

        public List<VariableData> Responses { get; set; } = new List<VariableData>();
        public List<HierarchicalInterview> HierarchicalInterviews { get; set; }
        
    }
}
