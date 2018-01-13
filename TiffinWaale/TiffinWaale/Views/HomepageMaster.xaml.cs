using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiffinWaale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomepageMaster : ContentPage
    {
        public ListView ListView;

        public HomepageMaster()
        {
            InitializeComponent();

            BindingContext = new HomepageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HomepageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomepageMenuItem> MenuItems { get; set; }
            
            public HomepageMasterViewModel()
            {
                MenuItems = new ObservableCollection<HomepageMenuItem>(new[]
                {
                    new HomepageMenuItem { Id = 0, Title = "Profile" },
                    new HomepageMenuItem { Id = 1, Title = "Orders" }
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}