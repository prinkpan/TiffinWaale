using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiffinWaale.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiffinWaale.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SupplierDetailPage : TabbedPage
	{
        SupplierDetailViewModel viewModel;
		public SupplierDetailPage ()
		{
			InitializeComponent ();
		}

        public SupplierDetailPage(SupplierDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
	}
}