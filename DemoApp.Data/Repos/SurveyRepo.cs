using System;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Data;
using DemoApp.Data.Repos;
using Newtonsoft.Json;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;

namespace Data.Repos
{

    /// <summary>
    /// <para>
    /// A sample implementation of a survey data repository that is used by a Web API through dependency injection of an interface.
    /// </para>
    /// <para>
    /// This sample simply serves up data stored in a local file. In real life, the repository would serve up data from a backend system such as a database.
    /// </para>
    /// </summary>
    public class SurveyRepo : ISurveyRepo
    {
        private const string CustomerExperienceSurvey = "1e6cb0a1-2289-4650-9148-9fc3e6e129b2";
        private const string CerealAwarenessSurvey = "a4bd7eed-88df-4a57-86d6-396e3698022e";
        
        public SurveyDetail[] ListSurveys()
        {
            return new SurveyDetail[]
            {
                //new SurveyDetail { Id = CustomerExperienceSurvey , Name = "TS-001", Title = "Customer Experience Survey" },
                new SurveyDetail { Id = CerealAwarenessSurvey , Name = "TS-002", Title = "Cereal Awareness Survey" }
            };
        }
        
        public SurveyMetadata ReadSurveyMetadata(string id)
        {
            switch (id)
            {
                case CustomerExperienceSurvey:
                    return TS001.ReadMetadata();
                case CerealAwarenessSurvey:
                    return TS002.ReadMetadata();
                default:
                    throw new ArgumentException($"Unrecognised survey id {id}");
            }
        }

        public Interview[] ReadSurveydata(string surveyId, InterviewsQuery query, string rootPath)
        {
            if (query.Start == null && query.MaxLength != null || query.Start != null && query.MaxLength == null)
                throw new ArgumentException("Invalid paging arguments");

            //Load in "All Interviews"
            List<Interview> allInterviews = ReadAllInterviews(GetInterviewDataPath(rootPath, surveyId));

            //Filtering
            allInterviews = ApplyFiltering(allInterviews, query);

            if (query.Start > allInterviews.Count)
                throw new ArgumentException($"Invalid paging arguments");

            //Paging
            return allInterviews
                .Skip((query.Start ?? 1) - 1)  //-1 to convert 1-based start argument into zero based skip argument
                .Take(query.MaxLength ?? allInterviews.Count)
                .ToArray();
        }

        /// <summary>Simple filtering function</summary>
        private List<Interview> ApplyFiltering(List<Interview> interviews, InterviewsQuery query)
        {
            //Filter on Interview Ids
            if (query.InterviewIdents != null && query.InterviewIdents.Any())
                interviews = interviews.Where(i => query.InterviewIdents.Any(ident => ident == i.Ident)).ToList();

            //Filter on Date Last Changed
            if (query.Date != null)
                interviews = interviews.Where(i => i.Date >= query.Date).ToList();

            //Filter on Complete
            if (query.CompleteOnly)
                interviews = interviews.Where(i => i.Complete).ToList();

            //Filter on Questions
            if (query.Variables != null && query.Variables.Any())
            {
                foreach (var interview in interviews)
                {
                    interview.Responses = interview.Responses.Where(d => query.Variables.Contains(d.Ident)).ToList();
                }
            }

            return interviews;
        }

        private List<Interview> ReadAllInterviews(string path)
        {
            using (var streamReader = new System.IO.StreamReader(path))
            {
                return JsonConvert.DeserializeObject<List<Interview>>(streamReader.ReadToEnd());
            }
        }

        private string GetInterviewDataPath(string rootPath, string surveyId)
        {
            switch (surveyId)
            {
                case CustomerExperienceSurvey:
                    return $"{rootPath}\\Data\\TS-001.json";
                case CerealAwarenessSurvey:
                    return $"{rootPath}\\Data\\TS-002.json";
                default:
                    throw new ArgumentException($"Unrecognised survey: '{surveyId}'");
            }
        }
    }
}
 