using System;
using System.Collections.Generic;
using Domain.Interviews;
using Domain.Metadata;
using Logic.Query.Queries.NewFolder;

namespace Data.Common.Repos
{
    public interface ISurveyRepo
    {
        List<SurveyDetail> ListSurveys();
        SurveyMetadata ReadSurveyMetadata(string id);
        List<Interview> ReadSurveydata(InterviewsQuery query);
    }
}
