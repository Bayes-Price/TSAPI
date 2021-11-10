using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Data;
using Orthogonal.NSettings;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;
using TSAPI.Public.Queries;

namespace TSAPI.ApiBrowser
{
	public sealed partial class MainController : INotifyPropertyChanged
	{
		readonly JsonSerializerOptions SerOpts = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
		HttpClient _client;
		bool supportsErrorResponse;

		public MainController()
		{
			Settings = new RegistrySettings();
			ObsEndpoints = new ObservableCollection<string>(new string[]
			{
				"https://tsapi-demo.azurewebsites.net/",
				"https://rcsapps.azurewebsites.net/rubytsapi/"
			});
		}

		public void AppLoaded()
		{
			StatusMessage = "Disconnected";
		}

		public ISettingsProcessor Settings { get; }

		public async Task OpenEndpoint()
		{
			BusyMessage = "Loading survey list\u2026";
			try
			{
				var tempclient = new HttpClient();
				if (!_endpoint.EndsWith("/")) Endpoint += "/";
				tempclient.BaseAddress = new Uri(_endpoint);

				#region ------- Metadata --------
				// EXPERIMENTAL
				// Probe the service to see if it returns metadata key-value pairs.
				// If it does, then one of the items tells us if it returns a standard
				// error reponse for all non-200 responses. This is an API extension
				// vaguely proposed by Red Centre Software.
				var message = await tempclient.GetAsync("service/metadata");
				if (message.StatusCode == System.Net.HttpStatusCode.OK)
				{
					string metajson = await message.Content.ReadAsStringAsync();
					var jagged = JsonSerializer.Deserialize<string[][]>(metajson, SerOpts);
					ServiceMetadata = jagged.ToDictionary(x => x[0], x => x[1]);
					CompanyName = _serviceMetadata.TryGetValue("Company", out string s1) ? s1 : null;
					supportsErrorResponse = _serviceMetadata.TryGetValue("ErrorResponseType", out string s2) ? s2 == typeof(ErrorResponse).Name : false;
				}
				else
				{
					CompanyName = null;
					supportsErrorResponse = false;
				}
				#endregion

				string json = await tempclient.GetStringAsync("Surveys");
				SurveyDetail[] surveyList = JsonSerializer.Deserialize<SurveyDetail[]>(json, SerOpts);
				ObsSurveys = new ObservableCollection<SurveyDetail>(surveyList);
				ViewSurveys = new ListCollectionView(_obsSurveys);
				ViewSurveys.SortDescriptions.Add(new SortDescription(nameof(SurveyDetail.Name), ListSortDirection.Ascending));
				StatusMessage = $"Connected - Survey count: {_obsSurveys.Count}";
				_client = tempclient;
				CloseAlert();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
				AppErrorTitle = "List surveys failed";
				AppErrorDetails = ex.Message;
			}
			BusyMessage = null;
		}

		public async Task LoadMetadata()
		{
			BusyMessage = $"Loading {_selectedSurvey.Name} metadata\u2026";
			try
			{
				var response = await _client.GetAsync($"Surveys/{_selectedSurvey.Id}/Metadata");
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					string json = await response.Content.ReadAsStringAsync();
					Metadata = JsonSerializer.Deserialize<SurveyMetadata>(json, SerOpts);
					ObsMetaNodes = new ObservableCollection<AppNode>(MetaToNodes());
					CloseAlert();
				}
				else
				{
					if (supportsErrorResponse)
					{
						string json = await response.Content.ReadAsStringAsync();
						var error = JsonSerializer.Deserialize<ErrorResponse>(json, SerOpts);
						throw new ApplicationException(error.Message);
					}
					response.EnsureSuccessStatusCode();
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
				AppErrorTitle = "Load metadata failed";
				AppErrorDetails = ex.Message;
			}
			BusyMessage = null;
		}

		public async Task ListInterviews()
		{
			BusyMessage = $"Loading {_selectedSurvey.Name} interviews\u2026";
			List<string> ToList(string value) => value?.Split(",; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
			try
			{
				var query = new InterviewsQuery()
				{
					SurveyId = _selectedSurvey.Id,
					CompleteOnly = _queryCompleteOnly,
					Start = _queryPagingStart,
					MaxLength = _queryPagingCount,
					Date = QueryDate,
					InterviewIdents = ToList(_queryVariables),
					Variables = ToList(_queryInterviewIds)
				};
				string postjson = JsonSerializer.Serialize(query);
				var content = new StringContent(postjson, Encoding.UTF8, "application/json");
				var response = await _client.PostAsync("Surveys/Interviews", content);
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					string json = await response.Content.ReadAsStringAsync();
					var interviews = JsonSerializer.Deserialize<Interview[]>(json, SerOpts);
					ObsInterviews = new ObservableCollection<Interview>(interviews);
					ObsInterviewNodes = new ObservableCollection<AppNode>(InterviewsToNodes());
					CloseAlert();
				}
				else
				{
					if (supportsErrorResponse)
					{
						string json = await response.Content.ReadAsStringAsync();
						var error = JsonSerializer.Deserialize<ErrorResponse>(json, SerOpts);
						throw new ApplicationException(error.Message);
					}
					response.EnsureSuccessStatusCode();
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
				AppErrorTitle = "Load interviews failed";
				AppErrorDetails = ex.Message;
			}
			BusyMessage = null;
		}

		/// <summary>
		/// Experimental 'push' of metadata to a specified receiving web service url.
		/// </summary>
		public async Task ExportMetadata()
		{
			BusyMessage = "Exporting metadata\u2026";
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(_exportMetaUrl);
					string metajson = JsonSerializer.Serialize(_metadata);
					var content = new StringContent(metajson, Encoding.UTF8);
					var response = await client.PostAsync("metadata", content);
					Trace.WriteLine($"Export response status code = {response.StatusCode}");
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
				AppErrorTitle = "Export metadata failed";
				AppErrorDetails = ex.Message;
			}
			BusyMessage = null;
		}

		public void CloseAlert()
		{
			AppErrorTitle = AppErrorDetails = null;
		}

		#region -------- TSAPI data to node helpers --------

		IEnumerable<AppNode> MetaToNodes()
		{
			var baseNode = new AppNode(NodeType.Folder, "Base Information", _metadata, null);
			baseNode.IsExpanded = true;
			UnwindMetaBase(_metadata, baseNode);
			yield return baseNode;
			if (_metadata.Hierarchies != null)
			{
				var hsNode = new AppNode(NodeType.Folder, "Hierarchies", null, baseNode);
				foreach (var hier in _metadata.Hierarchies)
				{
					var hNode = new AppNode(NodeType.Dummy, hier.Ident, hier, hsNode);
					hsNode.AddChild(hNode);
					if (hier.Parent != null)
					{
						var hpNode = new AppNode(NodeType.Dummy, hier.Ident, hier.Parent, hNode);
						hNode.AddChild(hpNode);
					}
					if (hier.Metadata != null)
					{
						var hmNode = new AppNode(NodeType.Folder, hier.Ident, null, hNode);
						hNode.AddChild(hmNode);
						UnwindMetaBase(hier.Metadata, hmNode);
					}
				}
				yield return hsNode;
			}
		}

		IEnumerable<AppNode> InterviewsToNodes()
		{
			var isNode = new AppNode(NodeType.Folder, "Interviews", _obsInterviews, null);
			isNode.IsExpanded = true;
			yield return isNode;
			foreach (var interview in _obsInterviews)
			{
				var iNode = new AppNode(NodeType.Interview, interview.Ident, interview, isNode);
				isNode.AddChild(iNode);
				if (interview.DataItems != null)
				{
					var disNode = new AppNode(NodeType.Folder, "Data Items", interview.DataItems, iNode);
					iNode.AddChild(disNode);
					foreach (DataItem di in interview.DataItems)
					{
						var diNode = new AppNode(NodeType.DataItem, di.Ident, di, disNode);
						disNode.AddChild(diNode);
						var vsNode = new AppNode(NodeType.Folder, "Values", di.Values, diNode);
						diNode.AddChild(vsNode);
						if (di.Values != null)
						{
							foreach (object value in di.Values)
							{
								var vNode = new AppNode(NodeType.InterviewValue, value.ToString(), value, vsNode);
								vsNode.AddChild(vNode);
							}
						}
						var lrsNode = new AppNode(NodeType.Folder, "Loop Refs", di.LoopRefs, diNode);
						diNode.AddChild(lrsNode);
						if (di.LoopRefs != null)
						{
							foreach (LoopRef lr in di.LoopRefs)
							{
								var lrNode = new AppNode(NodeType.LoopRef, lr.ValueIdent, lr, lrsNode);
								lrsNode.AddChild(lrNode);
							}
						}
					}
				}
			}
		}

		void UnwindMetaBase(SurveyMetadataBase metabase, AppNode parentNode)
		{
			var secsNode = new AppNode(NodeType.Folder, "Sections", null, parentNode);
			parentNode.AddChild(secsNode);
			foreach (var section in metabase.Sections)
			{
				var secNode = new AppNode(NodeType.Section, section.Label.Text, section, secsNode);
				secsNode.AddChild(secNode);
				UnwindVariables(section.Variables, secNode);
			}
			secsNode.IsExpanded = true;
			var secexp = secsNode.Children.OrderBy(n => n.Children.Count)?.LastOrDefault();
			if (secexp != null)
			{
				secexp.IsExpanded = true;
			}
		}

		void UnwindVariables(IEnumerable<Variable> variables, AppNode parentNode)
		{
			if (variables == null || variables.Count() == 0) return;
			foreach (var variable in variables)
			{
				string varlabel = variable.Label.Text;
				if (variable is OtherSpecifyVariable osv)
				{
					varlabel += $" ({osv.ParentValueIdent})";
				}
				var varNode = new AppNode(NodeType.Variable, varlabel, variable, parentNode);
				parentNode.AddChild(varNode);
				if (variable.Values != null)
				{
					var valsNode = new AppNode(NodeType.Folder, "Values", null, varNode);
					varNode.AddChild(valsNode);
					if (variable.Values.Values != null)
					{
						foreach (var value in variable.Values.Values)
						{
							var valNode = new AppNode(NodeType.Value, value.Label.Text, value, valsNode);
							valsNode.AddChild(valNode);
						}
					}
				}
				if (variable.LoopedVariables != null)
				{
					var lvNode = new AppNode(NodeType.Folder, "Looped Variables", null, varNode);
					varNode.AddChild(lvNode);
					UnwindVariables(variable.LoopedVariables, lvNode);
				}
				if (variable.OtherSpecifyVariables != null)
				{
					var osvNode = new AppNode(NodeType.Folder, "Other Specify Variables", null, varNode);
					varNode.AddChild(osvNode);
					UnwindVariables(variable.OtherSpecifyVariables, osvNode);
				}
			}
		}

		#endregion

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
