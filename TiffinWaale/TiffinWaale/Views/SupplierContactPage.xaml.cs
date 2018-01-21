using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using TiffinWaale.Models;
using TiffinWaale.ViewModels;

namespace TiffinWaale.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SupplierContactPage : ContentPage
	{
		public SupplierContactPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var position = await GetDeviceLocation();
                if (position != null)
                {
                    TiffinMap.MoveToRegion(
                        MapSpan.FromCenterAndRadius(
                            new Position(
                                position.Latitude,
                                position.Longitude
                            ),
                            Distance.FromKilometers(3)
                        )
                    );
                }
                else
                {
                    await DisplayAlert("Error", "Could not get your device's current location", "OK");
                }

                //if (viewModel.Suppliers.Count == 0)
                //    viewModel.LoadSuppliersCommand.Execute(null);

                //TODO: Show pins on map using https://forums.xamarin.com/discussion/19840/binding-pins-on-map-view-to-collection
            }
            catch
            {
                //TODO: Handle error
            }
        }

        private async Task<Plugin.Geolocator.Abstractions.Position> GetDeviceLocation()
        {
            Plugin.Geolocator.Abstractions.Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                //locator.PositionChanged += GPSLocationChanged;
                //await locator.StartListeningAsync(TimeSpan.FromTicks(0), 50);

                position = await locator.GetLastKnownLocationAsync();
                if (position != null)
                {
                    await Task.CompletedTask;
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    await Task.CompletedTask;
                }

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
            }
            catch (Exception ex)
            {
                //TODO: Handle error
                await Task.CompletedTask;
            }

            if (position == null)
                await Task.CompletedTask;

            var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

            //Debug.WriteLine(output);

            return position;
        }
    }
}