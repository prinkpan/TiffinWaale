using System;

using TiffinWaale.Views;
using TiffinWaale.Services;
using Xamarin.Forms;

namespace TiffinWaale
{
	public partial class App : Application
	{
		public static bool UseMockDataStore = true;
		public static string AzureMobileAppUrl = "https://[CONFIGURE-THIS-URL].azurewebsites.net";

		public App ()
		{
			InitializeComponent();

			if (UseMockDataStore)
            {
                DependencyService.Register<MockDataStore>();
                DependencyService.Register<MockSuppliers>();
            }
			else
				DependencyService.Register<AzureDataStore>();

            MainPage = new Homepage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
