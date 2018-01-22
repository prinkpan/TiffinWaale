using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TiffinWaale.Controls;
using TiffinWaale.Models;
using Xamarin.Forms.Maps;

namespace TiffinWaale.ViewModels
{
    public class SupplierDetailViewModel : BaseViewModel
    {
        public Supplier Supplier { get; set; }
        public ObservableCollection<CustomPin> SupplierPin { get; set; }
        public SupplierDetailViewModel(Supplier supplier = null)
        {
            Title = supplier.Name;
            Supplier = supplier;

            SupplierPin = new ObservableCollection<CustomPin>
            {
                new CustomPin
                {
                    Type = PinType.Place,
                    Position = new Position(supplier.Latitude, supplier.Longitude),
                    Label = supplier.Name,
                    Address = supplier.Address
                }
            };
        }
    }
}
