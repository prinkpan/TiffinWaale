using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiffinWaale.Helper;
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

            //Show India by default
            TiffinMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(
                        23.3355388,
                        78.6230092
                    ),
                    Distance.FromKilometers(1650)
                )
            );

            GoToDeviceLocation();
            BindingContext = viewModel = new SuppliersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (viewModel.Suppliers.Count == 0)
                    viewModel.LoadSuppliersCommand.Execute(null);

                DependencyService.Get<IToastNotification>().LongTime($"Found {viewModel.Suppliers.Count} tiffin services near you.");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void GoToDeviceLocation()
        {
            Plugin.Geolocator.Abstractions.Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;

                position = await locator.GetLastKnownLocationAsync();
                if(position == null)
                {
                    if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
                    {
                        position = await locator.GetPositionAsync(TimeSpan.FromSeconds(30), null, true);
                    }
                }

                if (position == null)
                {
                    //TODO: Show message to user to enable GPS
                    DependencyService.Get<IToastNotification>().LongTime("Could not get your location.");
                    return;
                }
                else
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
            }
            catch(Exception ex)
            {
                DependencyService.Get<IToastNotification>().LongTime("Could not get your location. Please enable GPS.");
                Debug.WriteLine(ex);
                return;
            }
        }

        private void OnSupplierSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var supplier = e.SelectedItem as Supplier;
            if (supplier == null)
                return;

            Navigation.PushAsync(new SupplierDetailPage(new SupplierDetailViewModel(supplier)));
            ItemsListView.SelectedItem = null;
        }
    }
}