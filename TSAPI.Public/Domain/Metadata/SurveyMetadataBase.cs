using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    public class SurveyMetadataBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int InterviewCount { get; set; }
        public List<Language> Languages { get; set; }
        public string NotAsked { get; set; }
        public string NoAnswer { get; set; }

        public List<Section> Sections { get; set; }
    }
}
