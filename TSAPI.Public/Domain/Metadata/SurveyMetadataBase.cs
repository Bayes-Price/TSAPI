using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    public class SurveyMetadataBase
    {
        ///<summary>The human readable identifer assigned to the survey within the API system. For example, this may contain an internal job number such as "TS-002"</summary>
        public string Name { get; set; }
        /// <summary>The human-readable name assigned to the survey within the API system. For example, "Restaurant Satisfaction Survey"</summary>
        public string Title { get; set; }
        /// <summary>The total number of interviews within the survey</summary>
        public int InterviewCount { get; set; }
        /// <summary>List of language objects defining the languages used within the survey</summary>
        public List<Language> Languages { get; set; }
        
        /// <summary>List of variables (if any) defined at the root level of the survey</summary>
        public List<Variable> Variables { get; set; } = new List<Variable>();
        
        /// <summary>List of sub-sections (if any) defined at the root level of the survey</summary>
        public List<Section> Sections { get; set; }
    }
}
