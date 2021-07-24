using System;
using System.Collections.Generic;
using Domain.Interviews;
using Domain.Metadata;
using Logic.Query.Queries.NewFolder;

namespace Data.Common.Repos
{
    public interface ISurveyRepo
    {
        SurveyMetadata ReadSurveyMetadata(Guid id);
        List<Interview> ReadSurveydata(InterviewsQuery query);
    }
}
