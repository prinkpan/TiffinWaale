using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TiffinWaale.Models;

namespace TiffinWaale.ViewModels
{
    public class SupplierFilterViewModel : BaseViewModel
    {
        public List<Supplier> SuppliersList { get; set; }
        public ObservableCollection<Supplier> Suppliers { get; set; }

        public SupplierFilterViewModel(List<Supplier> suppliers)
        {
            SuppliersList = suppliers;
            Suppliers = new ObservableCollection<Supplier>(SuppliersList);
        }
    }
}
