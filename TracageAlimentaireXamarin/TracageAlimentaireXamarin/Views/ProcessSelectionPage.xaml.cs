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
	public partial class ProcessSelectionPage : ContentPage
	{
		public ProcessSelectionPage (ProcessSelectionViewModel vm)
		{
		    BindingContext = vm;
		    vm.Navigation = Navigation;
		    InitializeComponent();
		}
	}
}