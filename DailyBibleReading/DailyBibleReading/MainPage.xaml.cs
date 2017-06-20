using DailyBibleReading.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DailyBibleReading
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

		// page load stuff
		protected override async void OnAppearing()
		{
			// show the progress visualization
			Chapters.IsRefreshing = true;

			// clear the collections
			ChapterCollection.Clear();
			VerseCollection.Clear();

			await MainPageViewModel.PopulateCollections(ChapterCollection, VerseCollection);

			// hide the progress visualization
			Chapters.IsRefreshing = false;

			base.OnAppearing();
		}

		private void Refresh_Clicked(object sender, EventArgs e)
		{
		}

		private async void Settings_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Views.Settings());
		}

		private void Share_Clicked(object sender, EventArgs e)
		{
		}

		private void Verses_ItemTapped(object sender, ItemTappedEventArgs e)
		{
		}

		private void Chapters_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			// clear the collection
			VerseCollection.Clear();

			// the object sent from the click
			var selectedchapter = (ChapterItem)e.Item;

			// iterate through the object
			foreach (var verse in selectedchapter.verses)
			{
				var verseitem = new VerseItem();

				verseitem.VerseReference = selectedchapter.ChapterReference + ":" + verse.verse;
				verseitem.verse = verse.verse;
				verseitem.text = verse.text;

				// add the item
				VerseCollection.Add(verseitem);
			}

			// switch back to the verses page
			CurrentPage = Children[0];
		}
	}
}
