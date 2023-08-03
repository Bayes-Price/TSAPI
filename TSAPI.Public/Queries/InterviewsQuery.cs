using System;
using System.Collections.Generic;

namespace TSAPI.Public.Queries
{
    public class InterviewsQuery
    {
        //Paging
        public int? Start { get; set; } 
        public int? MaxLength { get; set; }

        //Filtering
        public bool CompleteOnly { get; set; }
        public List<string> Variables { get; set; }
        public List<string> InterviewIdents { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
