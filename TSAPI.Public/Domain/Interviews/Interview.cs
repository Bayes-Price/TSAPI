using System;
using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    public class Interview
    {
        public string Ident { get; set; }
        public DateTime Date { get; set; }
        public bool Complete { get; set; }

        public List<VariableData> Answers { get; set; } = new List<VariableData>();
        public List<HierarchicalInterview> HierarchicalInterviews { get; set; }
        
    }
}
