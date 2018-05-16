using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracage.ViewModels;
using Tracage.Views;
using TracageAlimentaireXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TracageAlimentaireXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage(ProductDetailViewModel vm)
        {
            BindingContext = vm;
            vm.Navigation = Navigation;
            InitializeComponent();
        }



        protected override bool OnBackButtonPressed()
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("Alert!", "you are going back to the main page", "Go back", "Stay");
                        if (result)
                            Application.Current.MainPage = new MainPage(new MainViewModel());
                    }
                );
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}