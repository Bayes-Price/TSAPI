using System;
using System.Collections.Generic;
using Data.Common.Repos;
using Domain.Survey;
using Domain.TripleS.V2;
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
        ///<summary>Returns a list of available Surveys</summary>
        [HttpGet]
        [Route("/Surveys/")]
        public List<SurveyDetail> Surveys()
        {
            return new List<SurveyDetail>
            {
                new SurveyDetail {Id = new Guid("1e6cb0a1-2289-4650-9148-9fc3e6e129b2"), Name = "SP5201-1", Title = "Historic House Exit Survey<br/>First Wave" },
                new SurveyDetail {Id = new Guid("e36c93b8-d9df-42a9-8d4e-42b647944a5e"), Name = "PR9012-HOUSEHOLD", Title = "Regional Travel Survey<br/>Households"  }
            };
        }

        /// <summary>Fetches the metadata for a specific survey</summary>
        [HttpGet]
        [Route("/Surveys/{surveyId}/Metadata")]
        public ActionResult<SurveyMetadata> Metadata(Guid surveyId)
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
        [HttpGet]
        [Route("/Surveys/{surveyId}/Interviews")]
        public ActionResult<List<Interview>> Interviews(Guid surveyId, int? start,  int? maxLength)
        {
            try
            {
                var data = _surveyRepo.ReadSurveydata(surveyId, start, maxLength);
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