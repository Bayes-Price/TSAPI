using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;

namespace TSAPI.Public
{
	/// <summary>
	/// A strongly-typed TSAPI web service client for the convience of .NET developers.
	/// </summary>
	public class TsapiClient : IDisposable
	{
		readonly HttpClient _client;
		readonly JsonSerializerOptions jopts = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

		/// <summary>
		/// Constructs a client using a specified service base address string.
		/// </summary>
		/// <param name="serviceBaseAddress">Service base address.</param>
		public TsapiClient(string serviceBaseAddress)
			: this(new Uri(serviceBaseAddress))
		{
		}

		/// <summary>
		/// Constructs a client using a specified service base address Uri.
		/// </summary>
		/// <param name="serviceBaseUri">Service base address.</param>
		public TsapiClient(Uri serviceBaseUri)
		{
			ServiceBase = serviceBaseUri;
			_client = new HttpClient();
			_client.BaseAddress = serviceBaseUri;
		}

		/// <ignore/>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <ignore/>
		protected virtual void Dispose(bool disposing)
		{
			_client?.Dispose();
		}

		/// <summary>
		/// Gets the service base address.
		/// </summary>
		public Uri ServiceBase { get; }

		/// <summary>
		/// Lists summary information for all available surveys.
		/// </summary>
		/// <returns>An array of <c>SurveyDetail</c> objects.</returns>
		public async Task<SurveyDetail[]> ListSurveys()
		{
			string json = await _client.GetStringAsync("Surveys");
			return JsonSerializer.Deserialize<SurveyDetail[]>(json, jopts);
		}

		/// <summary>
		/// Gets the metadata for a specific survey.
		/// </summary>
		/// <param name="surveyId">The Id of the survey to retrieve.</param>
		/// <returns>A <c>SurveyMetadata</c> object or null of the <paramref name="surveyId"/> is not found.</returns>
		public async Task<SurveyMetadata> GetMetadata(string surveyId)
		{
			if (surveyId == null) throw new ArgumentNullException(nameof(surveyId));
			string json = await _client.GetStringAsync($"Surveys/{surveyId}/Metadata");
			return JsonSerializer.Deserialize<SurveyMetadata>(json, jopts);
		}

		/// <summary>
		/// Lists interview results for a specific survey with filtering parameters.
		/// </summary>
		/// <param name="query">Query filtering parameters.</param>
		/// <returns>An array <c>Interview</c> objects or null if the survey Id was not found</returns>
		public async Task<Interview[]> ListInterviewsFiltered(InterviewsQuery query)
		{
			if (query == null) throw new ArgumentNullException(nameof(query));
			string contentJson = JsonSerializer.Serialize(query);
			var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync("Surveys/Interviews", content);
			response.EnsureSuccessStatusCode();
			string json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<Interview[]>(json, jopts);
		}
	}
}
