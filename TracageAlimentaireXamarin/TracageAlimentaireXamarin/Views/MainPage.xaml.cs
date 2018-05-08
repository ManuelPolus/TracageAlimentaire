using Tracage.ViewModels;
using System;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Tracage.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {

        }
        public MainPage(MainViewModel vm)
        {
            BindingContext = vm;
            vm.Navigation = Navigation;
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

        private void ScannerButton_OnClicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("You are not connected", "You should be connected to the internet to proceed","GOT IT !");
            }
        }
    }
}
