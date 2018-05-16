using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TracageAlimentaireXamarin.Droid.Annotations;
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
