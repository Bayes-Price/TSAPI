using System;
using System.Collections.Generic;
using Domain.Interviews;
using Domain.Metadata;

namespace Data.Common.Repos
{
    public interface ISurveyRepo
    {
        SurveyMetadata ReadSurveyMetadata(Guid id);
        List<Interview> ReadSurveydata(Guid id, int? start, int? numberOfRecords);
    }
}
