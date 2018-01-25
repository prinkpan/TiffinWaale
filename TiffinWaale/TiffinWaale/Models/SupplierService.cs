using System;
using System.Collections.Generic;
using System.Text;

namespace TiffinWaale.Models
{
    public class SupplierService
    {
        public string SupplierServiceId { get; set; }
        public bool Lunch { get; set; }
        public bool Dinner { get; set; }
        public bool Vegeterian { get; set; }
        public bool NonVegeterian { get; set; }
        public bool Jain { get; set; }
        public bool Delivery { get; set; }
        public bool TakeAway { get; set; }
        public double ServiceRadius { get; set; }

        public virtual Supplier Supplier { get; set; } //Just a placeholder, not using is currently
    }
}
