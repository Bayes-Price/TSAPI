using System.Collections.Generic;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;

namespace DemoApp.Data.Common.Repos
{
    public interface ISurveyRepo
    {
        List<SurveyDetail> ListSurveys();
        SurveyMetadata ReadSurveyMetadata(string id);
        List<Interview> ReadSurveydata(InterviewsQuery query);
    }
}
