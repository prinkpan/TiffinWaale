using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TiffinWaale.Controls;
using TiffinWaale.Models;
using TiffinWaale.Views;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TiffinWaale.ViewModels
{
    public class SuppliersViewModel : BaseViewModel
    {
        public ObservableCollection<Supplier> Suppliers { get; set; }
        public ObservableCollection<CustomPin> SupplierPins { get; set; }
        public Plugin.Geolocator.Abstractions.Position UserPosition { get; set; }
        public double MapRadius { get; set; } = 3;

        public Command LoadSuppliersCommand { get; set; }

        public SuppliersViewModel()
        {
            Title = "Suppliers";
            Suppliers = new ObservableCollection<Supplier>();
            SupplierPins = new ObservableCollection<CustomPin>();

            LoadSuppliersCommand = new Command(async () => await ExecuteLoadSuppliersCommand());

            MessagingCenter.Subscribe<Homepage, Supplier>(this, "AddSupplier", async (obj, supplier) =>
            {
                var _supplier = supplier as Supplier;
                Suppliers.Add(_supplier);
                await SupplierDataStore.AddItemAsync(_supplier);
            });
        }

        async Task ExecuteLoadSuppliersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Geocoder geoCoder = new Geocoder();
                Suppliers.Clear();
                SupplierPins.Clear();
                var suppliers = await SupplierDataStore.GetItemsAsync(true);
                foreach (var supplier in suppliers)
                {
                    if (supplier.Latitude == 0 && supplier.Longitude == 0)
                    {
                        var approximateLocations = await geoCoder.GetPositionsForAddressAsync(supplier.Address);
                        foreach (var position in approximateLocations)
                        {
                            supplier.Latitude = position.Latitude;
                            supplier.Longitude = position.Longitude;
                            break;
                        }
                    }

                    var distance = Distance(UserPosition.Latitude, UserPosition.Longitude, supplier.Latitude, supplier.Longitude, 'K');

                    if(distance <= MapRadius)
                    {
                        Suppliers.Add(supplier);

                        SupplierPins.Add(new CustomPin
                        {
                            Type = PinType.Place,
                            Position = new Position(supplier.Latitude, supplier.Longitude),
                            Label = supplier.Name,
                            Address = supplier.Address,
                            Color = Color.Red,
                            Opacity = 100
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            //http://www.geodatasource.com/developers/c-sharp
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        private double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double Rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
