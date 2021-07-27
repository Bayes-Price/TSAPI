using System;
using System.Linq;
using Data.Common.Repos;
using Domain.Interviews;
using Domain.Metadata;
using Logic.Query.Queries.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace TSAPI.Controllers
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
        /// Lists summary information for all surveys.
        /// </summary>
        /// <returns>A serialized array of <c>SurveyDetail.</c></returns>
		/// <response code="200">The response body contains a serialized array of <code>SurveyDetail</code></response>
        [HttpGet]
        [Route("/Surveys/")]
        public SurveyDetail[] Surveys()
        {
            return _surveyRepo.ListSurveys().ToArray();
        }

        /// <summary>Fetches the metadata for a specific survey</summary>
        [HttpGet]
        [Route("/Surveys/{surveyId}/Metadata")]
        public ActionResult<SurveyMetadata> Metadata(string surveyId)
        {
            try
            {
                var metadata = _surveyRepo.ReadSurveyMetadata(surveyId);
                return Ok(metadata);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        /// <summary>Fetches some interview records for a specific survey</summary>
        [HttpPost]
        [Route("/Surveys/Interviews")]
        public ActionResult<Interview[]> Interviews(InterviewsQuery query)
        {
            try
            {
                var data = _surveyRepo.ReadSurveydata(query).ToArray();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        #endregion

    }
}