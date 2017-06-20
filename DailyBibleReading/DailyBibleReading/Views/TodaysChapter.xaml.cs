using DailyBibleReading.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyBibleReading.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodaysChapter : ContentPage
	{
		public TodaysChapter()
		{
			InitializeComponent();
		}

		// page load stuff
		protected override async void OnAppearing()
		{
			// great examples of working with dates (http://www.dotnetperls.com/datetime)
			var today = DateTime.Today.ToString("yyyy-MM-dd");

			// show the progress visualization
			Verses.IsRefreshing = true;

			var verses = await TodaysChapterViewModel.GetVersesAsync(today);
			// if no data
			if (verses.Count == 0)
			{
				await DisplayAlert("Connection Error", "Unable to retrieve data from the API.", "OK");
			}

			// bind the data to the view
			this.BindingContext = verses;

			// hide the progress visualization
			Verses.IsRefreshing = false;

			base.OnAppearing();
		}

		private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
		}
	}
}