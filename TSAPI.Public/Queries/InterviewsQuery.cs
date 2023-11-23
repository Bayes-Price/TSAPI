using System;
using System.Collections.Generic;

namespace TSAPI.Public.Queries
{
    /// <summary>Object containing parameters available for GET /Interviews endpoint</summary>
    public class InterviewsQuery
    {
        /// <summary>The position of the first record to return. This number is 1-based.</summary>
        public int? Start { get; set; } 
        /// <summary>The total number of records to return. The API may return fewer if the number of records available is less than MaxLength.</summary>
        public int? MaxLength { get; set; }

        /// <summary>If True the API will return only interviews considered "complete" by the API system. If False, the API will select from all interviews</summary>
        public bool CompleteOnly { get; set; }
        /// <summary>Return data from a subset of variables, specified as an array of variableId values. If empty, returns data for all variables.</summary>
        public List<string> Variables { get; set; }
        /// <summary>Return data from a subset of interviews, specified as an arrary of interviewId values. If empty, returns data for all interviews.</summary>
        public List<string> InterviewIdents { get; set; }
        /// <summary>Filter data on interviews created or updated on or after DateFrom</summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>Filter data on interviews created or updated on or before DateTo</summary>
        public DateTime? DateTo { get; set; }
    }
}
