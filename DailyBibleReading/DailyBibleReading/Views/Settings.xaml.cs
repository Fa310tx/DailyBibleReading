using System;

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
		}

		private void VersionPicker_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void FontSizePicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var newfontsize = FontSizePicker.SelectedIndex + 10;
			LoremIpsum.FontSize = newfontsize;

			// store the user preferences
			// get the device name
			//var deviceid = CrossDeviceInfo.Current.Id;
			// set the preference
		}
	}
}