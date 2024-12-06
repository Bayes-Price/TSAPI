using DemoApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;
using TSAPI.Public.Domain.Interviews;

namespace DemoApp.TSAPI.Controllers
{
    /// <summary>
    /// <para>
    /// A sample Web API controller with a public API that conforms the the TSAPI standard.
    /// This minimal class may be expanded to perform whatever internal processing is required
    /// to access survey data and handle other cross-cutting concerns such as logging, asynchrony,
    /// authentication and authorization. However, the public API must not change.
    /// </para>
    /// <para>
    /// See: <a href="https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0">Create web APIs with ASP.NET Core</a>.
    /// </para>
    /// </summary>
	[ApiController]
    public class SurveysController : ControllerBase
    {
        private ISurveyRepo _surveyRepo;
        private IWebHostEnvironment _hostingEnvironment;

        public SurveysController(ISurveyRepo surveyRepo, IWebHostEnvironment hostingEnvironment)
        {
            _surveyRepo = surveyRepo;
            _hostingEnvironment = hostingEnvironment;
        }

        #region Public API

        /// <summary>Lists summary information for all surveys.</summary>
        /// <returns>A serialized array of <c>SurveyDetail.</c></returns>
		/// <response code="200">The response body contains a serialized array of <code>SurveyDetail</code></response>
        [HttpGet]
        [Route("/surveys/")]
        [Produces("application/json", "text/xml")]
        [ProducesResponseType(typeof(SurveyDetail[]), StatusCodes.Status200OK)]
        public SurveyDetail[] Surveys()
        {
            return _surveyRepo.ListSurveys();
        }

        /// <summary>
        ///   Fetches the metadata for a specific survey
        /// </summary>
        /// <param name="id">The id of the survey metadata to retrieve.</param>
        /// <returns>
        ///   A serialized <c>SurveyMetadata.</c>
        /// </returns>
		/// <response code="200">The response body contains a serialized <code>SurveyMetadata</code>.</response>
        [HttpGet]
        [Route("/surveys/{id}/metadata")]
        [Produces("application/json", "text/xml")]
        [ProducesResponseType(typeof(SurveyMetadata), StatusCodes.Status200OK)]
        public SurveyMetadata Metadata(string id)
        {
            return _surveyRepo.ReadSurveyMetadata(id);
        }

        /// <summary>
        ///   Fetches some interview records for a specific survey.
        /// </summary>
        /// <param name="id">The id of the survey being queried for data</param>
        /// <param name="query">The request body contains a serialized <c>InterviewsQuery</c> containing filtering parameters.</param>
        /// <returns>
        ///   A serialized array of <c>Interview.</c>
        /// </returns>
        /// <response code="200">The response body contains a serialized <code>SurveyMetadata</code>.</response>
        [HttpGet]
        [Route("/surveys/{id}/interviews")]
        [Produces("application/json", "text/xml")]
        [ProducesResponseType(typeof(Interview[]), StatusCodes.Status200OK)]
        public Interview[] Interviews(string id, [FromQuery] InterviewsQuery query)
        {
            return _surveyRepo.ReadSurveydata(id, query, _hostingEnvironment.ContentRootPath);
        }

        #endregion
    }
}