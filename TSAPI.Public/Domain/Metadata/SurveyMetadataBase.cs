using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    public class SurveyMetadataBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int InterviewCount { get; set; }
        public List<Language> Languages { get; set; }
        
        /// <summary>List of variables (if any) defined at the root level of the survey</summary>
        public List<Variable> Variables { get; set; } = new List<Variable>();
        
        /// <summary>List of sub-sections (if any) defined at the root level of the survey</summary>
        public List<Section> Sections { get; set; }
    }
}
