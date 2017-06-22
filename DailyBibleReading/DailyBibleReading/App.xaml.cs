
using Xamarin.Forms;

namespace DailyBibleReading
{
	public partial class App : Application
    {
		public App()
        {
            InitializeComponent();

			// load the main page
			MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override void OnStart()
        {
			/*
			// azure mobile analytics
			MobileCenter.Start("android=7d921a5a-c740-47fb-97da-061e018aa5ac;" +
				"ios=c8821ea6-ed12-4445-8cc5-b60623bbebce;" +
				"uwp=33410f43-a0fc-4185-b696-dda752e6b2da;",				   
				typeof(Analytics), typeof(Crashes));
			*/
		}

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
