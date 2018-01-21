using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiffinWaale.Models;
using TiffinWaale.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TiffinWaale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomepageDetail : ContentPage
    {
        SuppliersViewModel viewModel;
        public HomepageDetail()
        {
            InitializeComponent();
            BindingContext = viewModel = new SuppliersViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var position = await GetDeviceLocation();
                if(position != null)
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

                if (viewModel.Suppliers.Count == 0)
                    viewModel.LoadSuppliersCommand.Execute(null);

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
                if(position != null)
                {
                    await Task.CompletedTask;
                }

                if(!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    await Task.CompletedTask;
                }

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
            }
            catch(Exception ex)
            {
                //TODO: Handle error
                await Task.CompletedTask;
            }

            if (position == null)
                await Task.CompletedTask;

            var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

            Debug.WriteLine(output);

            return position;
        }

        private void OnSupplierSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var supplier = e.SelectedItem as Supplier;
            if (supplier == null)
                return;

            Navigation.PushAsync(new SupplierDetailPage(new SupplierDetailViewModel(supplier)));
            ItemsListView.SelectedItem = null;
        }

        //private void GPSLocationChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        //{
        //    TiffinMap.MoveToRegion(
        //        MapSpan.FromCenterAndRadius(
        //            new Position(
        //                e.Position.Latitude,
        //                e.Position.Longitude
        //            ),
        //            Distance.FromKilometers(3)
        //        )
        //    );
        //}
    }
}