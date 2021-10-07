using System;
using System.Threading.Tasks;
using DemoApp.Data.Common.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;

namespace DemoApp.TSAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveysController : ControllerBase
    {

        #region "Member Variables"
        private ISurveyRepo _surveyRepo;
        #endregion

        #region "Construction"
        public SurveysController(ISurveyRepo surveyRepo)
        {
            _surveyRepo = surveyRepo;
        }
        #endregion

        #region "Public Methods"

        /// <summary>
        ///   Lists summary information for all surveys.
        /// </summary>
        /// <returns>
        ///   A serialized array of <c>SurveyDetail.</c>
        /// </returns>
		/// <response code="200">The response body contains a serialized array of <code>SurveyDetail</code></response>
        [HttpGet]
        [Route("/Surveys/")]
        [Produces("application/json", "text/xml")]
        [ProducesResponseType(typeof(SurveyDetail[]), StatusCodes.Status200OK)]
        public async Task<SurveyDetail[]> Surveys()
        {
            return await _surveyRepo.ListSurveys();
        }

        /// <summary>
        ///   Fetches the metadata for a specific survey
        /// </summary>
        /// <param name="surveyId">The Id of the survey metadata to retrieve.</param>
        /// <returns>
        ///   A serialized <c>SurveyMetadata.</c>
        /// </returns>
		/// <response code="200">The response body contains a serialized <code>SurveyMetadata</code>.</response>
        [HttpGet]
        [Route("/Surveys/{surveyId}/Metadata")]
        [Produces("application/json", "text/xml")]
        [ProducesResponseType(typeof(SurveyMetadata), StatusCodes.Status200OK)]
        public async Task<SurveyMetadata> Metadata(string surveyId)
        {
            return await _surveyRepo.ReadSurveyMetadata(surveyId);
        }

        /// <summary>
        ///   Fetches some interview records for a specific survey.
        /// </summary>
        /// <param name="query">The request body contains a serialized <c>InterviewsQuery</c> containing filtering parameters.</param>
        /// <returns>
        ///   A serialized array of <c>Interview.</c>
        /// </returns>
		/// <response code="200">The response body contains a serialized <code>SurveyMetadata</code>.</response>
        [HttpPost]
        [Route("/Surveys/Interviews")]
        [Produces("application/json", "text/xml")]
        [ProducesResponseType(typeof(Interview[]), StatusCodes.Status200OK)]
        public async Task<Interview[]> Interviews([FromBody] InterviewsQuery query)
        {
            return await _surveyRepo.ReadSurveydata(query);
        }

        #endregion
    }
}