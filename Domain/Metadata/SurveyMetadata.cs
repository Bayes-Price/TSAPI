using System.Collections.Generic;

namespace Domain.Metadata
{
    public class SurveyMetadata : SurveyMetadataBase
    {
        public List<Hierarchy> Hierarchies { get; set; } = new List<Hierarchy>();
    }
}
