using System;
using System.Collections.Generic;
using Data.Repos;
using Domain.Survey;
using Microsoft.AspNetCore.Mvc;

namespace TSAPI.Controllers
{
    ///<summary>Contains methods for demo purposes - the methods are NOT part of the TSAPI spec</summary>
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        ///<summary>Creates an account in the Demo system</summary>
        [HttpGet]
        [Route("/CreateAccount/")]
        public void CreateAccount(string companyName)
        {
            
            var repo = new ConfigRepo();
            repo.CreateAccount(companyName);
        }
    }
}