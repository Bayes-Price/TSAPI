using System;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;
using System.Linq;
using System.Text.RegularExpressions;

namespace DemoApp.Data.Repos.TripleS
{
    /// <summary>
    /// <para>
    /// A sample implementation of a survey data repository that is used by a Web API through
    /// dependency injection of an interface.
    /// </para>
    /// <para>
    /// This sample simply returns survey data uploaded as TripleS files into Azure blob storage.
    /// </para>
    /// </summary>
    public class SurveyRepo : ISurveyRepo
    {

        #region "Member Variables"
        private const string AppSettingAzureConnection = "AzureStorageConnectionString";
        private const string AppSettingTripleSContainer = "triplesdata";
        #endregion

        /// <summary>
        ///  Iterate through each of the files in the blob storage and return one survey for each file 
        /// </summary>
        /// <returns></returns>
        public SurveyDetail[] ListSurveys()
        {
            var containerClient = GetBlobClient();
            return containerClient.GetBlobs().Select(b => new SurveyDetail { Id = ParseId(b.Name), Name = ParseName(b.Name) }).ToArray();
        }

        public Interview[] ReadSurveydata(InterviewsQuery query, string path)
        {
            throw new NotImplementedException();
        }

        public SurveyMetadata ReadSurveyMetadata(string id)
        {
            throw new NotImplementedException();
        }

        #region "Private Methods"
        private Azure.Storage.Blobs.BlobContainerClient GetBlobClient()
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings[AppSettingAzureConnection];
            //Hack.
            if (connectionString == null)
                connectionString = "DefaultEndpointsProtocol=https;AccountName=tsapi;AccountKey=VJ7O7WD5S0ltfyZH+P+NGg9k3fjHV5pBZt5F1K1+WvbjZGWqj85z1RckU96kbLRyfGregJfQ+Y6u+ASt3e4UYg==;EndpointSuffix=core.windows.net";
            return new Azure.Storage.Blobs.BlobContainerClient (connectionString, AppSettingTripleSContainer);
        }
        private string ParseId(string filename)
        {
            return Regex.Match(filename, @"\d+(?=-)").Value;
        }
        private string ParseName(string filename)
        {
            return Regex.Match(filename, @"(?<=-).+(?=.zip)").Value;
        }
        #endregion

    }
}
