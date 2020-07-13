using System.Collections.Generic;
using Domain.Survey;

namespace TSAPI.ViewModels.Result
{
    public class SurveysResult : ApiResult
    {
        public List<SurveyDetail> Result { get; set; }
    }
}
