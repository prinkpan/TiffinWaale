using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TiffinWaale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomepageDetail : ContentPage
    {
        public HomepageDetail()
        {
            InitializeComponent();
            GetLocation();
        }

        private async void GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromTicks(10000));
            TiffinMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(
                        position.Latitude,
                        position.Longitude
                    ),
                    Distance.FromKilometers(1)
                )
            );
        }
    }
}