using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TiffinWaale.Models;
using TiffinWaale.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiffinWaale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SupplierFilter : ContentPage
	{
        SupplierFilterViewModel viewModel;
		public SupplierFilter ()
		{
			InitializeComponent ();
		}

        public SupplierFilter(SupplierFilterViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FilterEntry.Focus();
        }

        private void OnSupplierSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var supplier = e.SelectedItem as Supplier;
            if (supplier == null)
                return;

            Navigation.PushAsync(new SupplierDetailPage(new SupplierDetailViewModel(supplier)));
            ItemsListView.SelectedItem = null;
        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Suppliers.Clear();
            foreach (var supplier in viewModel.SuppliersList)
            {
                if (supplier.Name.IndexOf(e.NewTextValue, StringComparison.InvariantCultureIgnoreCase) >= 0
                    || supplier.Address.IndexOf(e.NewTextValue, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    viewModel.Suppliers.Add(supplier);
                }
            }
        }

        private void OnFilterToggle(object sender, ToggledEventArgs e)
        {
            viewModel.Suppliers.Clear();
            var switchControl = sender as Switch;
            var controlToggled = e.Value;

            //if(switchControl)
        }
    }
}