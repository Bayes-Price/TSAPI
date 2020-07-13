using System.Collections.Generic;

namespace Domain.TripleS.V2
{
    public class SurveyMetadataBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public List<Variable> Variables { get; set; } = new List<Variable>();
        public int InterviewCount { get; set; }
    }
}
