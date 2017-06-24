using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyBibleReading.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
		public Settings()
		{
			InitializeComponent();

			List<string> FontSizes = new List<string>();
			for (int i = 0; i < 50; i++)
			{
				FontSizes.Add(i.ToString());
			}

			List<string> Versions = new List<string> { "asv1901", "bbe", "darby", "kjv", "nasb", "niv", "nkjv", "nlt", "rsv", "web", "ylt" };
			
			// connect the data to the interface
			// data binding for today's chapter
			FontSizePicker.BindingContext = FontSizes;
			// data binding for reading schedule
			VersionPicker.BindingContext = Versions;
		}

		private void LoadPreferences()
		{
			FontSizePicker.SelectedIndex = Helpers.Settings.FontSize;

			switch (Helpers.Settings.Version)
			{
				case "b_asv1901":
					VersionPicker.SelectedIndex = 0;
					break;
				case "b_bbe":
					VersionPicker.SelectedIndex = 1;
					break;
				case "b_darby":
					VersionPicker.SelectedIndex = 2;
					break;
				case "b_kjv":
					VersionPicker.SelectedIndex = 3;
					break;
				case "b_nasb":
					VersionPicker.SelectedIndex = 4;
					break;
				case "b_niv":
					VersionPicker.SelectedIndex = 5;
					break;
				case "b_nkjv":
					VersionPicker.SelectedIndex = 6;
					break;
				case "b_nlt":
					VersionPicker.SelectedIndex = 7;
					break;
				case "b_rsv":
					VersionPicker.SelectedIndex = 8;
					break;
				case "b_web":
					VersionPicker.SelectedIndex = 9;
					break;
				case "b_ylt":
					VersionPicker.SelectedIndex = 10;
					break;
			}
		}

		// page load stuff
		protected override void OnAppearing()
		{
			LoadPreferences();

			base.OnAppearing();
		}

		private void VersionPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var version = "b_" + VersionPicker.SelectedItem.ToString();
			CrossSettings.Current.AddOrUpdateValue("Version", version);
		}

		private void FontSizePicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var newfontsize = FontSizePicker.SelectedIndex;
			LoremIpsum.FontSize = newfontsize;

			// store the user preferences
			// get the device name
			//var deviceid = CrossDeviceInfo.Current.Id;
			// set the preference
			CrossSettings.Current.AddOrUpdateValue("FontSize", newfontsize);
		}
	}
}