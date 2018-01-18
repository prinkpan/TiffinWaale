﻿using System;
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
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ek khaana hai mujhe",
                    Address1 = "Rite Fortune",
                    Address2 = "Dahanukarwadi, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067"
                },
                new Supplier {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Mujhe khaana do",
                    Address1 = "C-31, Shravasti, Off G.M. Link Rd",
                    Address2 = "Near InOrbit Mall, Malad(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400064"
                },
                new Supplier {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Khaa-teen-daari",
                    Address1 = "A-701, Vishwamilan",
                    Address2 = "Dahanukarwadi, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067"
                },
                new Supplier {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Chaar guna lagaan",
                    Address1 = "Madhurima Society",
                    Address2 = "Patel Nagar, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067"
                },
                new Supplier {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Paancho paanch",
                    Address1 = "Shubh Shanti Complex, Mahatma Gandhi Rd",
                    Address2 = "Dahanukarwadi, Kandivali(West)",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    Pincode = "400067"
                },
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
            var _supplier = suppliers.Where((Supplier arg) => arg.Id == supplier.Id).FirstOrDefault();
            suppliers.Remove(_supplier);

            return await Task.FromResult(true);
        }

        public async Task<Supplier> GetItemAsync(string id)
        {
            return await Task.FromResult(suppliers.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Supplier>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(suppliers);
        }

        public async Task<bool> UpdateItemAsync(Supplier supplier)
        {
            var _supplier = suppliers.Where((Supplier arg) => arg.Id == supplier.Id).FirstOrDefault();
            suppliers.Remove(_supplier);
            suppliers.Add(supplier);

            return await Task.FromResult(true);
        }
    }
}