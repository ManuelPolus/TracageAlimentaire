using Rg.Plugins.Popup.Pages;
using TracageAlimentaireXamarin.ViewModels;

namespace TracageAlimentaireXamarin.Views
{
    public partial class StepInfoPage : PopupPage
	{
		public StepInfoPage (StepInfoViewModel vm)
		{
            BindingContext = vm;
            vm.Navigation = Navigation;
            InitializeComponent ();
		}


	}
}