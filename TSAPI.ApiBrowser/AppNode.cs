using System;
using System.Collections.Generic;
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
		Dummy
	}

	public sealed class AppNode
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
			if (Children == null)
			{
				Children = new ObservableCollection<AppNode>();
			}
			Children.Add(child);
		}

		public override string ToString()
		{
			return $"AppNode({Type},{Label},{Data},{Parent?.Label})";
		}

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

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
