using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class StepInfoViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
