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
            var lunchLabel = new Label();
            if (viewModel.Supplier.Services.Lunch)
            {
                lunchLabel = new Label { Text = "Lunch", BackgroundColor = Color.LightGreen, LineBreakMode = LineBreakMode.NoWrap };
            }
            else
            {
                lunchLabel = new Label { Text = "Lunch", BackgroundColor = Color.Gray,  LineBreakMode = LineBreakMode.NoWrap };
            }
            ServiceTypeStackLayout.Children.Add(lunchLabel);

            var dinnerLabel = new Label();
            if (viewModel.Supplier.Services.Dinner)
            {
                dinnerLabel = new Label { Text = "Dinner", BackgroundColor = Color.LightGreen, LineBreakMode = LineBreakMode.NoWrap };
            }
            else
            {
                dinnerLabel = new Label { Text = "Dinner", BackgroundColor = Color.Gray,  LineBreakMode = LineBreakMode.NoWrap };
            }
            ServiceTypeStackLayout.Children.Add(dinnerLabel);

            //FoodCategory
            var vegeterianLabel = new Label();
            if (viewModel.Supplier.Services.Vegeterian)
            {
                vegeterianLabel = new Label { Text = "Vegeterian", BackgroundColor = Color.LightGreen, LineBreakMode = LineBreakMode.NoWrap };
            }
            else
            {
                vegeterianLabel = new Label { Text = "Vegeterian", BackgroundColor = Color.Gray, LineBreakMode = LineBreakMode.NoWrap };
            }
            FoodCategoryStackLayout.Children.Add(vegeterianLabel);

            var nonVegeterianLabel = new Label();
            if (viewModel.Supplier.Services.NonVegeterian)
            {
                nonVegeterianLabel = new Label { Text = "Non-Vegeterian", BackgroundColor = Color.LightGreen, LineBreakMode = LineBreakMode.NoWrap };
            }
            else
            {
                nonVegeterianLabel = new Label { Text = "Non-Vegeterian", BackgroundColor = Color.Gray, LineBreakMode = LineBreakMode.NoWrap };
            }
            FoodCategoryStackLayout.Children.Add(nonVegeterianLabel);

            //Delivery Details
            var homeDeliveryLabel = new Label();
            if (viewModel.Supplier.Services.HomeDelivery)
            {
                homeDeliveryLabel = new Label { Text = "Home Delivery", BackgroundColor = Color.LightGreen, LineBreakMode = LineBreakMode.NoWrap };
            }
            else
            {
                homeDeliveryLabel = new Label { Text = "Home Delivery", BackgroundColor = Color.Gray, LineBreakMode = LineBreakMode.NoWrap };
            }
            DeliveryStackLayout.Children.Add(homeDeliveryLabel);

            var takeAwayLabel = new Label();
            if (viewModel.Supplier.Services.TakeAway)
            {
                takeAwayLabel = new Label { Text = "Take AwayLabel", BackgroundColor = Color.LightGreen, LineBreakMode = LineBreakMode.NoWrap };
            }
            else
            {
                takeAwayLabel = new Label { Text = "Take AwayLabel", BackgroundColor = Color.Gray, LineBreakMode = LineBreakMode.NoWrap };
            }
            DeliveryStackLayout.Children.Add(takeAwayLabel);

            //Cuisine
            var cuisineLabel = new Label();
            if (viewModel.Supplier.Services.Cuisine.ToString() != "")
            {
                cuisineLabel = new Label { Text = "Take AwayLabel", BackgroundColor = Color.LightGreen, LineBreakMode = LineBreakMode.NoWrap };
            }
   



        }

    }
}