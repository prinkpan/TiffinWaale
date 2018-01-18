using System;
using System.Collections.Generic;
using System.Text;

namespace TiffinWaale.Models
{
    public class Supplier
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Address
        {
            get
            {
                StringBuilder address = new StringBuilder(Address1);
                if(!string.IsNullOrWhiteSpace(Address2))
                {
                    address.Append(", " + Address2);
                }
                address.Append(", " + City);
                address.Append(", " + State);
                address.Append(", " + Country);
                address.Append(", " + Pincode);
                return address.ToString();
            }
        }
    }
}
