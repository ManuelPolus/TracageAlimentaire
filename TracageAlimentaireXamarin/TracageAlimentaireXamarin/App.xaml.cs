using Java.Nio.Channels;
using Tracage.Views;
using Tracage.ViewModels;
using TracageAlimentaireXamarin.ViewModels;
using TracageAlimentaireXamarin.Views;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin
{
	public partial class App : Application
	{
		public App ()
		{
            InitializeComponent();
            MainPage = new MainPage(new MainViewModel());
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
