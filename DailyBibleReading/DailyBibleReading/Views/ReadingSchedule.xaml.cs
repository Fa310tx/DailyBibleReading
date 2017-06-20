using DailyBibleReading.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyBibleReading.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReadingSchedule : ContentPage
	{
		public ReadingSchedule()
		{
			InitializeComponent();
		}

		// page load stuff
		protected override async void OnAppearing()
		{
			// show the progress visualization
			Chapters.IsRefreshing = true;

			var chapters = await ReadingScheduleViewModel.GetChaptersAsync();
			// if no data
			if (chapters.Count == 0)
			{
				await DisplayAlert("Connection Error", "Unable to retrieve data from the API.", "OK");
			}

			// bind the data to the view
			this.BindingContext = chapters;

			// hide the progress visualization
			Chapters.IsRefreshing = false;

			base.OnAppearing();
		}

		private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{

		}
	}
}