using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using TiffinWaale.Models;
using TiffinWaale.ViewModels;
using System.Diagnostics;
using System.Collections.ObjectModel;
using TiffinWaale.Controls;
using TiffinWaale.Helper;

namespace TiffinWaale.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SupplierContactPage : ContentPage
	{
        public SupplierContactPage ()
		{
           InitializeComponent ();
        }

        public SupplierContactPage(SupplierDetailViewModel viewModel)
        {
            InitializeComponent();

            TiffinMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(
                        viewModel.Supplier.Latitude,
                        viewModel.Supplier.Longitude
                    ),
                    Distance.FromKilometers(3)
                )
            );
        }
    }
}