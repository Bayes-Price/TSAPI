using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    public class SurveyMetadataBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public List<Variable> Variables { get; set; } = new List<Variable>();
        public int InterviewCount { get; set; }
        public List<Language> Languages { get; set; }
        public string NotAsked { get; set; }
        public string NoAnswer { get; set; }
    }
}
