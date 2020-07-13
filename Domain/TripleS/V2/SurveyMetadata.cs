using System.Collections.Generic;

namespace Domain.TripleS.V2
{
    public class SurveyMetadata : SurveyMetadataBase
    {
        public List<Hierarchy> Hierarchies { get; set; } = new List<Hierarchy>();
    }
}
