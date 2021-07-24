using System;
using System.Collections.Generic;
using System.Linq;
using Data.Common.Repos;
using Domain.Interviews;
using Domain.Metadata;

namespace Data.Repos
{
    public class SurveyRepo : ISurveyRepo
    {
        #region "Constants"
        private const string SP5201Id = "1e6cb0a1-2289-4650-9148-9fc3e6e129b2";
        private const string PR9012Id = "e36c93b8-d9df-42a9-8d4e-42b647944a5e";
        #endregion

        #region "Public Methods"
        public SurveyMetadata ReadSurveyMetadata(Guid id)
        {
            switch (id.ToString())
            {
                case SP5201Id:
                    return Sp5201.ReadMetadata();
                //case PR9012Id:
                //    return PR9012_HOUSEHOLD.ReadMetadata();
                default:
                    throw new ArgumentException($"Unrecognised survey id {id}");
            }
        }

        public List<Interview> ReadSurveydata(Guid id, int? start, int? numberOfRecords)
        {
            if (start == null && numberOfRecords != null || start != null && numberOfRecords == null)
                throw new ArgumentException("Invalid paging arguments");

            List<Interview> allInterviews;

            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (id.ToString())
            {
                case SP5201Id:
                    allInterviews = Sp5201.LoadAllInterviews();
                    break;
                //case PR9012Id:
                //    allInterviews = PR9012_HOUSEHOLD.LoadAllInterviews();
                    //break;
                default:
                    throw new ArgumentException($"Unrecognised survey id {id}");
            }

            if (start > allInterviews.Count)
                throw new ArgumentException($"Invalid paging arguments");

            return allInterviews
                .Skip((start ?? 1) - 1)  //-1 to convert 1-based start argument into zero based skip argument
                .Take(numberOfRecords ?? allInterviews.Count)
                .ToList();
        }
        #endregion
    }
}
 