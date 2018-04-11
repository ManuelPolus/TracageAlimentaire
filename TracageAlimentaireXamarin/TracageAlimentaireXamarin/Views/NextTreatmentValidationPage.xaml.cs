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
	public partial class NextTreatmentValidationPage : ContentPage
	{
		public NextTreatmentValidationPage (NextTreatmentValidationViewModel vm)
		{
		    vm.Navigation = Navigation;
		    BindingContext = vm;
			InitializeComponent ();
		}
	}
}