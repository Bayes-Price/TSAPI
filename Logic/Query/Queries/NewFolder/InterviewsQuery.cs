using System;
using System.Collections.Generic;

namespace Logic.Query.Queries.NewFolder
{
    public class InterviewsQuery : BaseQuery
    {
        public string SurveyId { get; set; } 
        public int? Start { get; set; } 
        public int? MaxLength { get; set; }
        public bool CompleteOnly { get; set; }
        public List<string> Variables { get; set; }
        public List<string> InterviewIdents { get; set; }
        public DateTime? Date { get; set; }
    }
}
