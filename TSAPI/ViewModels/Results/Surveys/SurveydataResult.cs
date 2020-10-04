using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Domain.Survey;

namespace TSAPI.ViewModels.Results
{
    public class SurveydataResult :  ApiResult
    {
        public List<Interview> Interviews { get; set; }
        public int Start { get; set; }
        public int NumberOfRecords { get; set; }
        public int Total { get; set; }
    }
}
