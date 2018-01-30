using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiffinWaale.Models;

namespace TiffinWaale.Services
{
    public class MockSuppliers : IDataStore<Supplier>
    {
        List<Supplier> suppliers;

        public MockSuppliers()
        {
            suppliers = new List<Supplier>();
            var mockSuppliers = new List<Supplier>
            {
                new Supplier {
                    SupplierId = Guid.NewGuid().ToString(),
                    Name = "Ek khaana hai mujhe",
                    Address1 = "Rite Fortune",
                    Address2 = "Dahanukarwadi, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067",
                    PrimaryPhone = "9825142694",
                    AlternatePhone = "9825142694",
                    EmailAddress = "tiffin@gmail.com",
                    Latitude = 19.207690,
                    Longitude = 72.838814,
                    FoodRating = 4.5,
                    ServiceRating = 4.0,
                    Services = new SupplierService
                    {
                        SupplierServiceId = Guid.NewGuid().ToString(),
                        Lunch = true,
                        Dinner = true,
                        Vegeterian = true,
                        NonVegeterian = false,
                        Jain = true,
                        HomeDelivery = true,
                        HomeDeliveryArea = 20.0,
                        TakeAway = true,
                        Cuisine = "Panjabi, Gujarati, Rajasthani"
                    }
                },
                new Supplier {
                    SupplierId = Guid.NewGuid().ToString(),
                    Name = "Mujhe khaana do",
                    Address1 = "C-31, Shravasti, Off G.M. Link Rd",
                    Address2 = "Near InOrbit Mall, Malad(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400064",
                    PrimaryPhone = "9825142694",
                    AlternatePhone = "9825142694",
                    EmailAddress = "tiffin@gmail.com",
                    Latitude = 19.174108,
                    Longitude = 72.838282,
                    FoodRating = 3.0,
                    ServiceRating = 4.0,
                    Services = new SupplierService
                    {
                        SupplierServiceId = Guid.NewGuid().ToString(),
                        Lunch = true,
                        Dinner = true,
                        Vegeterian = true,
                        NonVegeterian = false,
                        Jain = false,
                        HomeDelivery = false,
                        HomeDeliveryArea = 20.0,
                        TakeAway = true,
                        Cuisine = "Panjabi, Gujarati, Rajasthani"
                    }
                },
                new Supplier {
                    SupplierId = Guid.NewGuid().ToString(),
                    Name = "Khaa-teen-daari",
                    Address1 = "A-701, Vishwamilan",
                    Address2 = "Dahanukarwadi, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067",
                    PrimaryPhone = "9825142694",
                    AlternatePhone = "9825142694",
                    EmailAddress = "tiffin@gmail.com",
                    Latitude = 19.208156,
                    Longitude = 72.838802,
                    FoodRating = 3.0,
                    ServiceRating = 4.5,
                    Services = new SupplierService
                    {
                        SupplierServiceId = Guid.NewGuid().ToString(),
                        Lunch = true,
                        Dinner = false,
                        Vegeterian = true,
                        NonVegeterian = true,
                        Jain = false,
                        HomeDelivery = false,
                        HomeDeliveryArea = 20.0,
                        TakeAway = true,
                        Cuisine = "Panjabi, Gujarati, Rajasthani"
                    }
                },
                new Supplier {
                    SupplierId = Guid.NewGuid().ToString(),
                    Name = "Chaar guna lagaan",
                    Address1 = "Madhurima Society",
                    Address2 = "Patel Nagar, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067",
                    PrimaryPhone = "9825142694",
                    AlternatePhone = "9825142694",
                    EmailAddress = "tiffin@gmail.com",
                    Latitude = 19.206579,
                    Longitude = 72.841896,
                    FoodRating = 5.0,
                    ServiceRating = 4.7,
                    Services = new SupplierService
                    {
                        SupplierServiceId = Guid.NewGuid().ToString(),
                        Lunch = true,
                        Dinner = true,
                        Vegeterian = true,
                        NonVegeterian = true,
                        Jain = false,
                        HomeDelivery = true,
                        HomeDeliveryArea = 20.0,
                        TakeAway = true,
                        Cuisine = "Panjabi, Gujarati, Rajasthani"
                    }
                },
                new Supplier {
                    SupplierId = Guid.NewGuid().ToString(),
                    Name = "Paancho paanch",
                    Address1 = "Shubh Shanti Complex, Mahatma Gandhi Rd",
                    Address2 = "Dahanukarwadi, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067",
                    PrimaryPhone = "9825142694",
                    AlternatePhone = "9825142694",
                    EmailAddress = "tiffin@gmail.com",
                    Latitude = 19.206515,
                    Longitude = 72.835750,
                    FoodRating = 3.3,
                    ServiceRating = 2.6,
                    Services = new SupplierService
                    {
                        SupplierServiceId = Guid.NewGuid().ToString(),
                        Lunch = true,
                        Dinner = true,
                        Vegeterian = true,
                        NonVegeterian = true,
                        Jain = true,
                        HomeDelivery = false,
                        HomeDeliveryArea = 20.0,
                        TakeAway = true,
                        Cuisine = "Panjabi, Gujarati, Rajasthani"
                    }
                },
                new Supplier {
                    SupplierId = Guid.NewGuid().ToString(),
                    Name = "ONE-GNR",
                    Address1 = "Sector 3C",
                    Address2 = "Near School",
                    City = "Gandhinagar",
                    State = "Gujarat",
                    Country = "India",
                    Pincode = "382003",
                    PrimaryPhone = "9870058120",
                    AlternatePhone = "9870058120",
                    EmailAddress = "tiffin@gmail.com",
                    Latitude = 23.208116,
                    Longitude = 72.629629,
                    FoodRating = 5.0,
                    ServiceRating = 5.0,
                    Services = new SupplierService
                    {
                        SupplierServiceId = Guid.NewGuid().ToString(),
                        Lunch = true,
                        Dinner = true,
                        Vegeterian = true,
                        NonVegeterian = false,
                        Jain = true,
                        HomeDelivery = true,
                        HomeDeliveryArea = 20.0,
                        TakeAway = true,
                        Cuisine = "Panjabi, Gujarati, Rajasthani"
                    }
                },
                new Supplier {
                    SupplierId = Guid.NewGuid().ToString(),
                    Name = "TWO-GNR",
                    Address1 = "Sector 3C",
                    Address2 = "Near School",
                    City = "Gandhinagar",
                    State = "Gujarat",
                    Country = "India",
                    Pincode = "382003",
                    PrimaryPhone = "9870058120",
                    AlternatePhone = "9870058120",
                    EmailAddress = "tiffin@gmail.com",
                    Latitude = 23.207823,
                    Longitude = 72.630433,
                    FoodRating = 4.0,
                    ServiceRating = 2.7,
                    Services = new SupplierService
                    {
                        SupplierServiceId = Guid.NewGuid().ToString(),
                        Lunch = false,
                        Dinner = true,
                        Vegeterian = false,
                        NonVegeterian = true,
                        Jain = true,
                        HomeDelivery = true,
                        HomeDeliveryArea = 20.0,
                        TakeAway = true,
                        Cuisine = "Panjabi, Gujarati, Rajasthani, Maharashtrian"
                    }
                }
            };

            foreach (var supplier in mockSuppliers)
            {
                suppliers.Add(supplier);
            }
        }

        public async Task<bool> AddItemAsync(Supplier supplier)
        {
            suppliers.Add(supplier);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Supplier supplier)
        {
            var _supplier = suppliers.Where((Supplier arg) => arg.SupplierId == supplier.SupplierId).FirstOrDefault();
            suppliers.Remove(_supplier);

            return await Task.FromResult(true);
        }

        public async Task<Supplier> GetItemAsync(string id)
        {
            return await Task.FromResult(suppliers.FirstOrDefault(s => s.SupplierId == id));
        }

        public async Task<IEnumerable<Supplier>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(suppliers);
        }

        public async Task<bool> UpdateItemAsync(Supplier supplier)
        {
            var _supplier = suppliers.Where((Supplier arg) => arg.SupplierId == supplier.SupplierId).FirstOrDefault();
            suppliers.Remove(_supplier);
            suppliers.Add(supplier);

            return await Task.FromResult(true);
        }
    }
}
