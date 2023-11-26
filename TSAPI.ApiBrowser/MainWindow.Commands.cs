using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace TSAPI.ApiBrowser
{
	internal static class MainCommands
	{
		public static RoutedUICommand CloseAlert = new("Close Alert", "CloseAlert", typeof(Window));
		public static RoutedUICommand LoadMetadata = new("Load Metadata", "LoadMetadata", typeof(Window));
		public static RoutedUICommand LoadInterviews = new("Load Interviews", "LoadInterviews", typeof(Window));
		public static RoutedUICommand ExportMetadata = new("Export Metadata", "ExportMetadata", typeof(Window));
	}

	partial class MainWindow
	{
		void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute =
			Controller.BusyMessage == null && IsUri(Controller.Endpoint);

		async void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e) => await Controller.OpenEndpoint();

		void CloseAlertCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = Controller.AppErrorTitle != null;

		void CloseAlertCmdExecuted(object target, ExecutedRoutedEventArgs e) => Controller.CloseAlert();

		void LoadMetadataCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = Controller.SelectedSurvey != null;

		async void LoadMetadataCmdExecuted(object target, ExecutedRoutedEventArgs e) => await Controller.LoadMetadata();

		void LoadInterviewsCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			if (Controller.BusyMessage != null) e.CanExecute = false;
			else if (Controller.SelectedSurvey == null) e.CanExecute = false;
			else if (Controller.QueryPagingStart == null && Controller.QueryPagingCount != null) e.CanExecute = false;
			else if (Controller.QueryPagingStart != null && Controller.QueryPagingCount == null) e.CanExecute = false;
			else e.CanExecute = true;
		}

		async void LoadInterviewsCmdExecuted(object target, ExecutedRoutedEventArgs e) => await Controller.ListInterviews();

		void ExportMetadataCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = Controller.Metadata != null && IsUri(Controller.ExportMetaUrl);

		async void ExportMetadataCmdExecuted(object target, ExecutedRoutedEventArgs e) => await Controller.ExportMetadata();

		static bool IsUri(string value) => !string.IsNullOrEmpty(value) &&
			Regex.IsMatch(value, @"^https?://.+") &&
			Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri _);
	}
}
