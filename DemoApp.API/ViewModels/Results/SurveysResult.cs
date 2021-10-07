using System.Collections.Generic;
using TSAPI.Public.Domain.Metadata;

namespace DemoApp.API.ViewModels.Results
{
    public class SurveysResult : ApiResult
    {
        public List<SurveyDetail> Result { get; set; }
    }
}
