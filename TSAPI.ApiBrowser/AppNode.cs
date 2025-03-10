using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TSAPI.ApiBrowser
{
	public enum NodeType
	{
		Folder,
		Section,
		Variable,
		Value,
		Interview,
		DataItem,
		InterviewValue,
		LoopRef,
		Grid,
		Row,
		AltLabel,
		ValueRef,
		Dummy
	}

	public sealed class AppNode : INotifyPropertyChanged
	{
		public AppNode(NodeType type, string label, object data, AppNode parent)
		{
			Type = type;
			Label = label;
			Data = data;
			Parent = parent;
		}

		public NodeType Type { get; }
		public string Label { get; }
		public object Data { get; }
		public AppNode Parent { get; set; }
		public ObservableCollection<AppNode> Children { get; private set; }

		public void AddChild(AppNode child)
		{
			Children ??= new ObservableCollection<AppNode>();
			Children.Add(child);
		}

		public override string ToString() => $"AppNode({Type},{Label},{Data},{Parent?.Label})";

		bool _isExpanded;
		public bool IsExpanded
		{
			get { return _isExpanded; }
			set
			{
				if (_isExpanded != value)
				{
					_isExpanded = value;
					OnPropertyChanged(nameof(IsExpanded));
				}
			}
		}

		bool _isSelected;
		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				if (_isSelected != value)
				{
					_isSelected = value;
					OnPropertyChanged(nameof(IsSelected));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
