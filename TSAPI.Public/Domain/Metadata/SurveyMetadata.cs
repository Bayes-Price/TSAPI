using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>Object representing a survey and all of its metadata (information about questionnaire variables)</summary>
    public class SurveyMetadata : SurveyMetadataBase
    {
        /// <summary>List of hierarchical questionnaires (if any) within a survey</summary>
        public List<Hierarchy> Hierarchies { get; set; } = new List<Hierarchy>();
    }
}
