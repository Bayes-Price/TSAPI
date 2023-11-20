using System;
using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    /// <summary>Object representing a completed interview in a survey</summary>
    public class Interview
    {
        /// <summary>Unique identifier of an interview</summary>
        public string InterviewId { get; set; }
        /// <summary>Date interview was last changed</summary>
        public DateTime Date { get; set; }
        /// <summary>Indicates whether the interview is considered a Complete interview or not</summary>
        public bool Complete { get; set; }

        /// <summary>List of responses given within the interview</summary>
        public List<VariableData> Responses { get; set; } = new List<VariableData>();
        public List<HierarchicalInterview> HierarchicalInterviews { get; set; }
        
    }
}
