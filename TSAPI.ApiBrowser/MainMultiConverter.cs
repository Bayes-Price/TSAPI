using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TSAPI.ApiBrowser
{
	internal class MainMultiConverter : IMultiValueConverter
	{
		static readonly BitmapImage FolderClosedIcon = new BitmapImage(new Uri("/Images/NodeFolderClosed.png", UriKind.Relative));
		static readonly BitmapImage FolderOpenIcon = new BitmapImage(new Uri("/Images/NodeFolderOpen.png", UriKind.Relative));
		static readonly BitmapImage SectionClosedIcon = new BitmapImage(new Uri("/Images/NodeSectionClosed.png", UriKind.Relative));
		static readonly BitmapImage SectionOpenIcon = new BitmapImage(new Uri("/Images/NodeSectionOpen.png", UriKind.Relative));
		static readonly BitmapImage VariableIcon = new BitmapImage(new Uri("/Images/NodeVariable.png", UriKind.Relative));
		static readonly BitmapImage ValueIcon = new BitmapImage(new Uri("/Images/NodeValue.png", UriKind.Relative));
		static readonly BitmapImage InterviewIcon = new BitmapImage(new Uri("/Images/NodeInterview.png", UriKind.Relative));
		static readonly BitmapImage DataItemIcon = new BitmapImage(new Uri("/Images/NodeDataItem.png", UriKind.Relative));
		static readonly BitmapImage InterviewValueIcon = new BitmapImage(new Uri("/Images/NodeInterviewValue.png", UriKind.Relative));
		static readonly BitmapImage LoopRefIcon = new BitmapImage(new Uri("/Images/NodeLoopRef.png", UriKind.Relative));
		static readonly BitmapImage GridIcon = new BitmapImage(new Uri("/Images/NodeGrid.png", UriKind.Relative));
		static readonly BitmapImage AltLabelIcon = new BitmapImage(new Uri("/Images/NodeAltLabel.png", UriKind.Relative));
		static readonly BitmapImage ValueRefIcon = new BitmapImage(new Uri("/Images/NodeValueRef.png", UriKind.Relative));
		static readonly BitmapImage DummyIcon = new BitmapImage(new Uri("/Images/NodeDummy.png", UriKind.Relative));

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			string convarg = (string)parameter;
			if (convarg == "Icon")
			{
				var type = values[0] as NodeType?;
				var expand = values[1] as bool?;
				if (type == NodeType.Folder) return expand == true ? FolderOpenIcon : FolderClosedIcon;
				if (type == NodeType.Section) return expand == true ? SectionOpenIcon : SectionClosedIcon;
				if (type == NodeType.Variable) return VariableIcon;
				if (type == NodeType.Value) return ValueIcon;
				if (type == NodeType.Interview) return InterviewIcon;
				if (type == NodeType.DataItem) return DataItemIcon;
				if (type == NodeType.InterviewValue) return InterviewValueIcon;
				if (type == NodeType.LoopRef) return LoopRefIcon;
				if (type == NodeType.Grid) return LoopRefIcon;
				if (type == NodeType.AltLabel) return AltLabelIcon;
				if (type == NodeType.ValueRef) return ValueRefIcon;
				return DummyIcon;
			}
			throw new NotImplementedException(nameof(Convert));
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException(nameof(ConvertBack));
		}
	}
}
