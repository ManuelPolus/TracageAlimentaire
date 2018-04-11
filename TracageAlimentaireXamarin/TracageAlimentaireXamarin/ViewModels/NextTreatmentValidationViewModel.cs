using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Droid.Annotations;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class NextTreatmentValidationViewModel : INotifyPropertyChanged
    {

        private Treatment treatmentToValidate;

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public NextTreatmentValidationViewModel(Product p)
        {
            try
            {
                this.treatmentToValidate = ProductChanger.FindNextTreatment(p);
            }
            catch (NullReferenceException nullex)
            {
                this.treatmentToValidate = new Treatment();
            }
        }


        public Treatment TreatmentToValidate
        {
            get { return treatmentToValidate; }
            set
            {
                if (treatmentToValidate != value)
                {
                    treatmentToValidate = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("TreatmentToValidate"));
                    }
                }
            }
        }


    }
}
