﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MetroRadiance.Chrome;
using MetroRadiance.Interop.Win32;
using MetroRadiance.Platform;
using Microsoft.Win32;

namespace MetroRadiance.Showcase.Views
{
	partial class MainWindow
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void OpenFileDialog(object sender, RoutedEventArgs e)
		{
			var dialog = new OpenFileDialog();
			if (dialog.ShowDialog() ?? false)
			{

			}
		}

		private async void Hide(object sender, RoutedEventArgs e)
		{
			this.Hide();

			await Task.Delay(2500);

			this.Visibility = Visibility.Visible;
		}

		protected override void OnContentRendered(EventArgs e)
		{
			base.OnContentRendered(e);
			SetGlowingForActiveWindow();
		}

		private static async void SetGlowingForActiveWindow()
		{
			await Task.Delay(2500);

			var hWnd = User32.GetForegroundWindow();
			//var hWnd = new IntPtr(0x015E0D0C);
			var external = new ExternalWindow(hWnd);
			var chrome = new WindowChrome();
			chrome.Attach(external);
		}
	}
}
