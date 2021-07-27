using System;
using System.Collections.Generic;
using System.Linq;
using Data.Common.Repos;
using Domain.Interviews;
using Domain.Metadata;
using Logic.Query.Queries.NewFolder;

namespace Data.Repos
{
	public class SurveyRepo : ISurveyRepo
    {
        #region "Constants"
        private const string SP5201Id = "1e6cb0a1-2289-4650-9148-9fc3e6e129b2";
        private const string PR9012Id = "e36c93b8-d9df-42a9-8d4e-42b647944a5e";
        #endregion

        #region "Public Methods"


        public List<SurveyDetail> ListSurveys()
        {
            return new List<SurveyDetail>()
            {
                new SurveyDetail { Id = "1e6cb0a1-2289-4650-9148-9fc3e6e129b2", Name = "SP5201-1", Title = "Historic House Exit Survey<br/>First Wave" } //,
                //new SurveyDetail { Id = "e36c93b8-d9df-42a9-8d4e-42b647944a5e", Name = "PR9012-HOUSEHOLD", Title = "Regional Travel Survey<br/>Households"  }
            };
        }
        
        public SurveyMetadata ReadSurveyMetadata(string id)
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

        public List<Interview> ReadSurveydata(InterviewsQuery query)
        {
            if (query.Start == null && query.MaxLength != null || query.Start != null && query.MaxLength == null)
                throw new ArgumentException("Invalid paging arguments");

            List<Interview> allInterviews;

            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (query.SurveyId.ToString())
            {
                case SP5201Id:
                    allInterviews = Sp5201.LoadAllInterviews();
                    break;
                //case PR9012Id:
                //    allInterviews = PR9012_HOUSEHOLD.LoadAllInterviews();
                    //break;
                default:
                    throw new ArgumentException($"Unrecognised survey id {query.SurveyId}");
            }


            //Filtering
            allInterviews = ApplyFiltering(allInterviews, query);

            if (query.Start > allInterviews.Count)
                throw new ArgumentException($"Invalid paging arguments");

            //Paging
            return allInterviews
                .Skip((query.Start ?? 1) - 1)  //-1 to convert 1-based start argument into zero based skip argument
                .Take(query.MaxLength ?? allInterviews.Count)
                .ToList();
        }
        #endregion

        #region "Private Methods"
        /// <summary>Crude simple filtering function</summary>
        private List<Interview> ApplyFiltering(List<Interview> allInterviews, InterviewsQuery query)
        {
            //Interview Ids
            if (query.InterviewIdents != null && query.InterviewIdents.Any())
                allInterviews = allInterviews.Where(i => query.InterviewIdents.Any(ident => ident == i.Ident)).ToList();

            //Date 
            //TODO:

            //Complete
            if (query.CompleteOnly)
                allInterviews = allInterviews.Where(i => i.Ident != "520001").ToList(); //Pretend that interview 1 is incomplete

            //Questions
            if (query.Variables != null && query.Variables.Any())
            {
                foreach (var interview in allInterviews)
                {
                    interview.DataItems = interview.DataItems.Where(d => query.Variables.Contains(d.Ident)).ToList();
                }
            }
            
            return allInterviews;

        }
        #endregion

    }
}
 