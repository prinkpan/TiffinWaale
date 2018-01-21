using System;
using System.Collections.Generic;
using System.Text;
using TiffinWaale.Models;

namespace TiffinWaale.ViewModels
{
    public class SupplierDetailViewModel : BaseViewModel
    {
        public Supplier Supplier { get; set; }
        public SupplierDetailViewModel(Supplier supplier = null)
        {
            Title = supplier.Name;
            Supplier = supplier;
        }
    }
}
