using System.Collections.Generic;
using Domain.Interviews;

namespace TSAPI.ViewModels.Result
{
    public class SurveysResult : ApiResult
    {
        public List<SurveyDetail> Result { get; set; }
    }
}
