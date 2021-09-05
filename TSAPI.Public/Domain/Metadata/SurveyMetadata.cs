using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    public class SurveyMetadata : SurveyMetadataBase
    {
        public List<Hierarchy> Hierarchies { get; set; } = new List<Hierarchy>();
    }
}
