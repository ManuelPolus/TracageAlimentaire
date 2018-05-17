using System.ComponentModel;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class AccessViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }

        public AccessViewModel()
        {

        }


       
    }
}
