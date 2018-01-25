using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiffinWaale.Models;
using TiffinWaale.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiffinWaale.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SupplierFilter : ContentPage
	{
        SuppliersViewModel viewModel;
		public SupplierFilter ()
		{
			InitializeComponent ();
		}

        public SupplierFilter(SuppliersViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        private void OnSupplierSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var supplier = e.SelectedItem as Supplier;
            if (supplier == null)
                return;

            Navigation.PushAsync(new SupplierDetailPage(new SupplierDetailViewModel(supplier)));
            ItemsListView.SelectedItem = null;
        }
    }
}