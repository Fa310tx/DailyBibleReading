using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

			List<string> VersionAbbreviations = new List<string>
			{
				"asv1901",
				"bbe",
				"cjb",
				"cev",
				"darby",
				"erv",
				"gnv",
				"gw",
				"gnt",
				"hnv",
				"hcsb",
				"kjv",
				"mkjv",
				"nasb",
				"ncv",
				"net",
				"nirv",
				"nkjv",
				"nlt",
				"nrsv",
				"rsv",
				"amp",
				"esv",
				"tlb",
				"msg",
				"niv",
				"tev",
				"tniv",
				"wbt",
				"web",
				"ylt",
			};
			List<string> VersionNames = new List<string>
			{
				"American Standard Version",
				"Bible In Basic English",
				"Complete Jewish Bible",
				"Contemporary English Version",
				"Darby Bible",
				"Easy-To-Read Version",
				"Geneva Bible",
				"God's Word",
				"Good News Translation",
				"Hebrew Names Version Of The World English Bible",
				"Holman Christian Standard Bible",
				"King James Version",
				"Modern King James Version",
				"New American Standard Bible",
				"New Century Version",
				"New English Translation",
				"New International Reader's Version",
				"New King James Version",
				"New Living Translation",
				"New Revised Standard Version",
				"Revised Standard Version",
				"The Amplified Bible",
				"The English Standard Version",
				"The Living Bible",
				"The Message",
				"The New International Version",
				"Today's English Version",
				"Today's New International Version",
				"Webster's Bible Translation",
				"World English Bible",
				"Young's Literal Translation",
			};
			Dictionary<string, string> VersionDictionary = new Dictionary<string, string>()
			{
				{ "asv1901", "American Standard Version" },
				{ "bbe", "Bible In Basic English" },
				{ "cjb", "Complete Jewish Bible" },
				{ "cev", "Contemporary English Version" },
				{ "darby", "Darby Bible" },
				{ "erv", "Easy-To-Read Version" },
				{ "gnv", "Geneva Bible" },
				{ "gw", "God's Word" },
				{ "gnt", "Good News Translation" },
				{ "hnv", "Hebrew Names Version Of The World English Bible" },
				{ "hcsb", "Holman Christian Standard Bible" },
				{ "kjv", "King James Version" },
				{ "mkjv", "Modern King James Version" },
				{ "nasb", "New American Standard Bible" },
				{ "ncv", "New Century Version" },
				{ "net", "New English Translation" },
				{ "nirv", "New International Reader's Version" },
				{ "nkjv", "New King James Version" },
				{ "nlt", "New Living Translation" },
				{ "nrsv", "New Revised Standard Version" },
				{ "rsv", "Revised Standard Version" },
				{ "amp", "The Amplified Bible" },
				{ "esv", "The English Standard Version" },
				{ "tlb", "The Living Bible" },
				{ "msg", "The Message" },
				{ "niv", "The New International Version" },
				{ "tev", "Today's English Version" },
				{ "tniv", "Today's New International Version" },
				{ "wbt", "Webster's Bible Translation" },
				{ "web", "World English Bible" },
				{ "ylt", "Young's Literal Translation" },
			};
			List<KeyValuePair<string, string>> VersionList = VersionDictionary.ToList();


			// connect the data to the interface
			// data binding for today's chapter
			FontSizePicker.BindingContext = FontSizes;
			// data binding for reading schedule
			VersionPicker.BindingContext = VersionList;
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
				case "b_cjb":
					VersionPicker.SelectedIndex = 2;
					break;
				case "b_cev":
					VersionPicker.SelectedIndex = 3;
					break;
				case "b_darby":
					VersionPicker.SelectedIndex = 4;
					break;
				case "b_erv":
					VersionPicker.SelectedIndex = 5;
					break;
				case "b_gnv":
					VersionPicker.SelectedIndex = 6;
					break;
				case "b_gw":
					VersionPicker.SelectedIndex = 7;
					break;
				case "b_gnt":
					VersionPicker.SelectedIndex = 8;
					break;
				case "b_hnv":
					VersionPicker.SelectedIndex = 9;
					break;
				case "b_hcsb":
					VersionPicker.SelectedIndex = 10;
					break;
				case "b_kjv":
					VersionPicker.SelectedIndex = 11;
					break;
				case "b_mkjv":
					VersionPicker.SelectedIndex = 12;
					break;
				case "b_nasb":
					VersionPicker.SelectedIndex = 13;
					break;
				case "b_ncv":
					VersionPicker.SelectedIndex = 14;
					break;
				case "b_net":
					VersionPicker.SelectedIndex = 15;
					break;
				case "b_nirv":
					VersionPicker.SelectedIndex = 16;
					break;
				case "b_nkjv":
					VersionPicker.SelectedIndex = 17;
					break;
				case "b_nlt":
					VersionPicker.SelectedIndex = 18;
					break;
				case "b_nrsv":
					VersionPicker.SelectedIndex = 19;
					break;
				case "b_rsv":
					VersionPicker.SelectedIndex = 20;
					break;
				case "b_amp":
					VersionPicker.SelectedIndex = 21;
					break;
				case "b_esv":
					VersionPicker.SelectedIndex = 22;
					break;
				case "b_tlb":
					VersionPicker.SelectedIndex = 23;
					break;
				case "b_msg":
					VersionPicker.SelectedIndex = 24;
					break;
				case "b_niv":
					VersionPicker.SelectedIndex = 25;
					break;
				case "b_tev":
					VersionPicker.SelectedIndex = 26;
					break;
				case "b_tniv":
					VersionPicker.SelectedIndex = 27;
					break;
				case "b_wbt":
					VersionPicker.SelectedIndex = 28;
					break;
				case "b_web":
					VersionPicker.SelectedIndex = 29;
					break;
				case "b_ylt":
					VersionPicker.SelectedIndex = 30;
					break;
				default:
					// default is kjv
					VersionPicker.SelectedIndex = 11;
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
			var selecteditem = VersionPicker.SelectedItem.ToString();
			// single quotes make it type Char while double quotes make it type String
			Char delimiter = ',';
			// create an array from the string separated by the delimiter
			String[] selecteditemparts = selecteditem.Split(delimiter);
			// take off the beginning character
			var selecteditemkey = selecteditemparts[0].Substring(1);
			// take off the beginning and ending character
			var selecteditemvalue = selecteditemparts[1].Substring(1, (selecteditemparts[1].Length - 2));
			var version = "b_" + selecteditemkey;

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