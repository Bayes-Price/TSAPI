using System.Threading.Tasks;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;

namespace DemoApp.Data.Common.Repos
{
	/// <summary>
	/// NOTE: A TSAPI data provider will implement this interface in a class that works with their backing storage.
	/// </summary>
	public interface ISurveyRepo
    {
        Task<SurveyDetail[]> ListSurveys();
        Task<SurveyMetadata> ReadSurveyMetadata(string id);
        Task<Interview[]> ReadSurveydata(InterviewsQuery query);
    }
}
