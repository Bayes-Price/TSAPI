using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;

namespace TSAPI.ApiBrowser
{
    partial class MainController
    {
        string _statusMessage = "Loading...";
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_statusMessage != newvalue)
                {
                    _statusMessage = newvalue;
					OnPropertyChanged(nameof(StatusMessage));
                }
            }
        }

        string _statusTime = "00:00:00";
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string StatusTime
        {
            get => _statusTime;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_statusTime != newvalue)
                {
                    _statusTime = newvalue;
					OnPropertyChanged(nameof(StatusTime));
                }
            }
        }

        string _busyMessage;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string BusyMessage
        {
            get => _busyMessage;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_busyMessage != newvalue)
                {
                    _busyMessage = newvalue;
					OnPropertyChanged(nameof(BusyMessage));
                }
            }
        }

        string _appErrorTitle;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string AppErrorTitle
        {
            get => _appErrorTitle;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_appErrorTitle != newvalue)
                {
                    _appErrorTitle = newvalue;
					OnPropertyChanged(nameof(AppErrorTitle));
                }
            }
        }

        string _appErrorDetails;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string AppErrorDetails
        {
            get => _appErrorDetails;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_appErrorDetails != newvalue)
                {
                    _appErrorDetails = newvalue;
					OnPropertyChanged(nameof(AppErrorDetails));
                }
            }
        }

        int _appFontSize = 12;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public int AppFontSize
        {
            get => _appFontSize;
            set
            {
                if (_appFontSize != value)
                {
                    _appFontSize = value;
					OnPropertyChanged(nameof(AppFontSize));
                }
            }
        }

        ObservableCollection<string> _obsEndpoints;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public ObservableCollection<string> ObsEndpoints
        {
            get => _obsEndpoints;
            set
            {
                if (_obsEndpoints != value)
                {
                    _obsEndpoints = value;
					OnPropertyChanged(nameof(ObsEndpoints));
                }
            }
        }

        string _companyName;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string CompanyName
        {
            get => _companyName;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_companyName != newvalue)
                {
                    _companyName = newvalue;
					OnPropertyChanged(nameof(CompanyName));
                }
            }
        }

        string _endpoint = "https://tsapi-demo.azurewebsites.net/";
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string Endpoint
        {
            get => _endpoint;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_endpoint != newvalue)
                {
                    _endpoint = newvalue;
					OnPropertyChanged(nameof(Endpoint));
                }
            }
        }

        Dictionary<string,string> _serviceMetadata;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public Dictionary<string,string> ServiceMetadata
        {
            get => _serviceMetadata;
            set
            {
                if (_serviceMetadata != value)
                {
                    _serviceMetadata = value;
					OnPropertyChanged(nameof(ServiceMetadata));
                }
            }
        }

        ObservableCollection<SurveyDetail> _obsSurveys;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public ObservableCollection<SurveyDetail> ObsSurveys
        {
            get => _obsSurveys;
            set
            {
                if (_obsSurveys != value)
                {
                    _obsSurveys = value;
					OnPropertyChanged(nameof(ObsSurveys));
                }
            }
        }

        ObservableCollection<Interview> _obsInterviews;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public ObservableCollection<Interview> ObsInterviews
        {
            get => _obsInterviews;
            set
            {
                if (_obsInterviews != value)
                {
                    _obsInterviews = value;
					OnPropertyChanged(nameof(ObsInterviews));
                }
            }
        }

        SurveyDetail _selectedSurvey;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public SurveyDetail SelectedSurvey
        {
            get => _selectedSurvey;
            set
            {
                if (_selectedSurvey != value)
                {
                    _selectedSurvey = value;
					OnPropertyChanged(nameof(SelectedSurvey));
                }
            }
        }

        ListCollectionView _viewSurveys;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public ListCollectionView ViewSurveys
        {
            get => _viewSurveys;
            set
            {
                if (_viewSurveys != value)
                {
                    _viewSurveys = value;
					OnPropertyChanged(nameof(ViewSurveys));
                }
            }
        }

        string _surveyQuickFilter;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string SurveyQuickFilter
        {
            get => _surveyQuickFilter;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_surveyQuickFilter != newvalue)
                {
                    _surveyQuickFilter = newvalue;
					OnPropertyChanged(nameof(SurveyQuickFilter));
                }
            }
        }

        SurveyMetadata _metadata;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public SurveyMetadata Metadata
        {
            get => _metadata;
            set
            {
                if (_metadata != value)
                {
                    _metadata = value;
					OnPropertyChanged(nameof(Metadata));
                }
            }
        }

        ObservableCollection<AppNode> _obsMetaNodes;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public ObservableCollection<AppNode> ObsMetaNodes
        {
            get => _obsMetaNodes;
            set
            {
                if (_obsMetaNodes != value)
                {
                    _obsMetaNodes = value;
					OnPropertyChanged(nameof(ObsMetaNodes));
                }
            }
        }

        ObservableCollection<AppNode> _obsInterviewNodes;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public ObservableCollection<AppNode> ObsInterviewNodes
        {
            get => _obsInterviewNodes;
            set
            {
                if (_obsInterviewNodes != value)
                {
                    _obsInterviewNodes = value;
					OnPropertyChanged(nameof(ObsInterviewNodes));
                }
            }
        }

        AppNode _selectedMetaNode;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public AppNode SelectedMetaNode
        {
            get => _selectedMetaNode;
            set
            {
                if (_selectedMetaNode != value)
                {
                    _selectedMetaNode = value;
					OnPropertyChanged(nameof(SelectedMetaNode));
                }
            }
        }

        AppNode _selectedInterviewNode;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public AppNode SelectedInterviewNode
        {
            get => _selectedInterviewNode;
            set
            {
                if (_selectedInterviewNode != value)
                {
                    _selectedInterviewNode = value;
					OnPropertyChanged(nameof(SelectedInterviewNode));
                }
            }
        }

        string _exportMetaUrl;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string ExportMetaUrl
        {
            get => _exportMetaUrl;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_exportMetaUrl != newvalue)
                {
                    _exportMetaUrl = newvalue;
					OnPropertyChanged(nameof(ExportMetaUrl));
                }
            }
        }

        int? _queryPagingStart = 1;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public int? QueryPagingStart
        {
            get => _queryPagingStart;
            set
            {
                if (_queryPagingStart != value)
                {
                    _queryPagingStart = value;
					OnPropertyChanged(nameof(QueryPagingStart));
                }
            }
        }

        int? _queryPagingCount = 200;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public int? QueryPagingCount
        {
            get => _queryPagingCount;
            set
            {
                if (_queryPagingCount != value)
                {
                    _queryPagingCount = value;
					OnPropertyChanged(nameof(QueryPagingCount));
                }
            }
        }

        bool _queryCompleteOnly;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public bool QueryCompleteOnly
        {
            get => _queryCompleteOnly;
            set
            {
                if (_queryCompleteOnly != value)
                {
                    _queryCompleteOnly = value;
					OnPropertyChanged(nameof(QueryCompleteOnly));
                }
            }
        }

        string _queryVariables;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string QueryVariables
        {
            get => _queryVariables;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_queryVariables != newvalue)
                {
                    _queryVariables = newvalue;
					OnPropertyChanged(nameof(QueryVariables));
                }
            }
        }

        string _queryInterviewIds;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public string QueryInterviewIds
        {
            get => _queryInterviewIds;
            set
            {
                string newvalue = string.IsNullOrEmpty(value) ? null : value;
                if (_queryInterviewIds != newvalue)
                {
                    _queryInterviewIds = newvalue;
					OnPropertyChanged(nameof(QueryInterviewIds));
                }
            }
        }

        DateTime? _queryDate;
		[GeneratedCode("TextTemplatingFileGenerator", "0.0.0.0")]
        public DateTime? QueryDate
        {
            get => _queryDate;
            set
            {
                if (_queryDate != value)
                {
                    _queryDate = value;
					OnPropertyChanged(nameof(QueryDate));
                }
            }
        }

    }
}
