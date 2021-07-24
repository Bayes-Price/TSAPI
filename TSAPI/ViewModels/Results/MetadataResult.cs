using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Metadata;

namespace TSAPI.ViewModels.Results
{
    public class MetadataResult : ApiResult
    {
        public SurveyMetadata Result { get; set; }
    }
}
