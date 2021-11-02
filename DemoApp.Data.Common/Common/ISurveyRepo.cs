using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;

namespace DemoApp.Data.Common.Repos
{
	/// <summary>
	/// This is a sample interface to a library that acts as a data processor for a custom repository of survey data.
    /// It is a convention that data processing is hidden behind an interface that is used by a Web API through
    /// dependency injection.
	/// </summary>
	public interface ISurveyRepo
    {
        SurveyDetail[] ListSurveys();
        SurveyMetadata ReadSurveyMetadata(string id);
        Interview[] ReadSurveydata(InterviewsQuery query);
    }
}
