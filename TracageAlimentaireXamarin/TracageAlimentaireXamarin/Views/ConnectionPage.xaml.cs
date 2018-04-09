using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracageAlimentaireXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TracageAlimentaireXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {
        public ConnectionPage(ConnectionViewModel vm)
        {
            vm.Navigation = Navigation;
            BindingContext = vm;

            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert!", "Do you really want to exit ?", "Leave", "Stay");
                if (result)
                    Environment.Exit(0);
            });

            return true;

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}