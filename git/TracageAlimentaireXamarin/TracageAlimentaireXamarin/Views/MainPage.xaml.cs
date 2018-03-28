using App2.ViewModels;
using System;
using Xamarin.Forms;

namespace App2.Views
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

    }
}
