using TracageAlimentaireXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TracageAlimentaireXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NextTreatmentValidationPage : ContentPage
	{
		public NextTreatmentValidationPage (NextTreatmentValidationViewModel vm)
		{
		    BindingContext = vm;
		    vm.Navigation = Navigation;
			InitializeComponent();
		}
	}
}