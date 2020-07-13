using System;
using System.Collections.Generic;
using Domain.Survey;
using Domain.TripleS.V2;

namespace Data.Common.Repos
{
    public interface ISurveyRepo
    {
        SurveyMetadata ReadSurveyMetadata(Guid id);
        List<Interview> ReadSurveydata(Guid id, int? start, int? numberOfRecords);
    }
}
