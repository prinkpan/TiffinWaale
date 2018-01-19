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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
