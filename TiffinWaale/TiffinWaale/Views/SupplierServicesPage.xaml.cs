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
	public partial class SupplierServicesPage : ContentPage
	{
		public SupplierServicesPage ()
		{
			InitializeComponent ();
		}

        public SupplierServicesPage(SupplierDetailViewModel viewModel)
        {
            InitializeComponent();

            //Service Type
            var lunchLabel = new Label { Text = "Lunch" };
            lunchLabel.Style = viewModel.Supplier.Services.Lunch ? (Style)Application.Current.Resources["LabelGreenText"] : (Style)Application.Current.Resources["LabelGrayText"];
            ServiceTypeStackLayout.Children.Add(lunchLabel);

            var dinnerLabel = new Label { Text = "Dinner" };
            dinnerLabel.Style = viewModel.Supplier.Services.Dinner ? (Style)Application.Current.Resources["LabelGreenText"] : (Style)Application.Current.Resources["LabelGrayText"];
            ServiceTypeStackLayout.Children.Add(dinnerLabel);

            //FoodCategory
            var vegeterianLabel = new Label { Text = "Vegeterian" };
            vegeterianLabel.Style = viewModel.Supplier.Services.Vegeterian ? (Style)Application.Current.Resources["LabelGreenText"] : (Style)Application.Current.Resources["LabelGrayText"];
            FoodCategoryStackLayout.Children.Add(vegeterianLabel);

            var nonVegeterianLabel = new Label { Text = "Non-Vegeterian" };
            nonVegeterianLabel.Style = viewModel.Supplier.Services.NonVegeterian ? (Style)Application.Current.Resources["LabelGreenText"] : (Style)Application.Current.Resources["LabelGrayText"];
            FoodCategoryStackLayout.Children.Add(nonVegeterianLabel);

            //Delivery Details
            var homeDeliveryLabel = new Label { Text = "Home Delivery" };
            homeDeliveryLabel.Style = viewModel.Supplier.Services.HomeDelivery ? (Style)Application.Current.Resources["LabelGreenText"] : (Style)Application.Current.Resources["LabelGrayText"];
            DeliveryStackLayout.Children.Add(homeDeliveryLabel);

            var takeAwayLabel = new Label { Text = "Take Away" };
            takeAwayLabel.Style = viewModel.Supplier.Services.TakeAway ? (Style)Application.Current.Resources["LabelGreenText"] : (Style)Application.Current.Resources["LabelGrayText"];
            DeliveryStackLayout.Children.Add(takeAwayLabel);

            //Cuisine
           if (viewModel.Supplier.Services.Cuisine.ToString() != "")
            {
                string[] cusines = viewModel.Supplier.Services.Cuisine.ToString().Split(',').Select(sValue => sValue.Trim()).ToArray();
                foreach (string cusineName in cusines)
                {
                    var cuisineLabel = new Label { Text = cusineName, Style = (Style)Application.Current.Resources["LabelGreenText"], };
                    CuisineLayout.Children.Add(cuisineLabel);
                }
            }
        }
    }
}