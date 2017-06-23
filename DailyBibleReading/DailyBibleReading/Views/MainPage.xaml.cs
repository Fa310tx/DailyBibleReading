using DailyBibleReading.ViewModels;
using Plugin.DeviceInfo;
using Plugin.Settings;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DailyBibleReading.Views
{
	public partial class MainPage : TabbedPage
	{
		public ObservableCollection<ChapterItem> ChapterCollection { get; set; }
		public ObservableCollection<VerseItem> VerseCollection { get; set; }

		public MainPage()
        {
            InitializeComponent();

			ChapterCollection = new ObservableCollection<ChapterItem>();
			VerseCollection = new ObservableCollection<VerseItem>();

			// connect the data to the interface
			// data binding for today's chapter
			Verses.BindingContext = VerseCollection;
			// data binding for reading schedule
			Chapters.BindingContext = ChapterCollection;
		}

		private void LoadPreferences()
		{
			Helpers.Settings.Version = CrossSettings.Current.GetValueOrDefault("Version", "b_kjv");
			Helpers.Settings.FontSize = Convert.ToInt32(CrossSettings.Current.GetValueOrDefault("FontSize", 16));
		}

		private async void GetDataAsync()
		{
			// show the progress visualization
			Chapters.IsRefreshing = true;

			// clear the collections
			ChapterCollection.Clear();
			VerseCollection.Clear();

			await MainPageViewModel.PopulateCollectionsAsync(ChapterCollection, VerseCollection, Helpers.Settings.Version);

			// hide the progress visualization
			Chapters.IsRefreshing = false;
		}

		// page load stuff
		protected override void OnAppearing()
		{
			GetDataAsync();
			LoadPreferences();

			base.OnAppearing();
		}

		// when a chapter is selected
		private void Chapters_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			// clear the collection
			VerseCollection.Clear();

			// the object sent from the click
			var selectedchapter = (ChapterItem)e.Item;

			selectedchapter.HasBeenRead = true;
			Helpers.Settings.HasBeenRead = DateTime.Parse(selectedchapter.date).ToString("yyyy-MM-dd");

			// iterate through the object
			foreach (var verse in selectedchapter.verses)
			{
				var verseitem = new VerseItem();

				verseitem.VerseReference = selectedchapter.ChapterReference + ":" + verse.verse;
				verseitem.verse = verse.verse;
				verseitem.text = verse.text;
				verseitem.DetailFontSize = Helpers.Settings.FontSize;
				verseitem.TitleFontSize = Convert.ToInt32(verseitem.DetailFontSize * 0.6);

				// add the item
				VerseCollection.Add(verseitem);
			}

			// switch back to the verses page
			CurrentPage = Children[0];
		}

		private void Refresh(object sender, EventArgs e)
		{
			GetDataAsync();
		}

		private async void Share(object sender, EventArgs e)
		{
			// see if a verse is selected
			try
			{
				// get the selected content
				// the extra () part is called casting
				// in this instance, SelectedItem is of type Object and type String doesn't know what to do with it
				// ToString() was attempted, but it gave the object's name instead if its content
				var reference = ((VerseItem)Verses.SelectedItem).VerseReference;
				var text = ((VerseItem)Verses.SelectedItem).text;
				var title = "From Daily Bible Reading App";
				var message = reference + "\r\n" + text;

				// share message and an optional title
				await CrossShare.Current.Share(new ShareMessage { Text = message, Title = title });
			}
			catch
			{
				// pop up an error message
				await DisplayAlert("No Verse Selected", "Please select a verse.", "OK");
			}
		}

		// website
		private void OpenBibleReadingPage(object sender, EventArgs e)
		{
			var url = "http://flcbranson.org/php/mlmBibleReading.php?site=flcb&pageKey=head4";
			Helper.OpenExternalPage(url);
		}

		// feedback
		private void SendEmail(object sender, EventArgs e)
		{
			var operatingsystem = CrossDeviceInfo.Current.Platform + " " + CrossDeviceInfo.Current.Version;

			var address = "jj@anti-exe.com";
			var subject = "Daily%20Bible%20Reading%20-%20Xamarin";
			var body = "\r\n\r\n" + operatingsystem + "\r\n\r\n";
			var url = "mailto:" + address + "?subject=" + subject + "&body=" + body;
			Helper.OpenExternalPage(url);
		}

		// more apps
		private void MoreFromDeveloper(object sender, EventArgs e)
		{
			var publisher = "Joshua Jackson";
		}

		private async void Settings(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Settings());
		}
	}
}
