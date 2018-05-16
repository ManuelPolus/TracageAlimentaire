using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Tracage.ViewModels;
using Tracage.Views;
using TracageAlimentaireXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TracageAlimentaireXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccessDenied : PopupPage
    {
        public AccessDenied(AccessViewModel vm)
        {
            BindingContext = vm;
            vm.Navigation = Navigation;
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Environment.Exit(0);
            return true;
        }
    }
}