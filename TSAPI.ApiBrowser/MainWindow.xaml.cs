using System;
using System.Windows;

namespace TSAPI.ApiBrowser
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			Loaded += MainWindow_Loaded;
			Closed += MainWindow_Closed;
			InitializeComponent();
			LoadWindowBounds();
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			Controller.AppLoaded();
		}

		void MainWindow_Closed(object sender, EventArgs e)
		{
			SaveWindowBounds();
		}

		void LoadWindowBounds()
		{
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			Rect r = Controller.Settings.Get(null, nameof(WindowStartupLocation), default(Rect));
			if (r.Width != 0)
			{
				WindowStartupLocation = WindowStartupLocation.Manual;
				Top = r.Top;
				Left = r.Left;
				Width = r.Width;
				Height = r.Height;
			}
		}

		void SaveWindowBounds()
		{
			if (WindowState == WindowState.Normal)
			{
				Controller.Settings.Put(null, nameof(WindowStartupLocation), new Rect(Left, Top, Width, Height));
			}
		}

		MainController Controller => (MainController)DataContext;

		private void MetaTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var node = (AppNode)e.NewValue;
			Controller.SelectedMetaNode = node;
		}

		private void InterviewTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var node = (AppNode)e.NewValue;
			Controller.SelectedInterviewNode = node;
		}

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
