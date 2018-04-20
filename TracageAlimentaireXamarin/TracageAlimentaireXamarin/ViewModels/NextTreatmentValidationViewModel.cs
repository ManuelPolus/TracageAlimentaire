using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Droid.Annotations;
using TracageAlimentaireXamarin.Views;
using TracageAlmentaireWeb.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class NextTreatmentValidationViewModel : INotifyPropertyChanged
    {

        private Treatment treatmentToValidate;
        private State state;

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public Command ValidateCommand { get; set; }

        public NextTreatmentValidationViewModel(Product p)
        {
            try
            {
                ValidateCommand = new Command(ValidateTreatment);
                this.P = p;

                this.treatmentToValidate = ProductChanger.FindNextTreatment(p);

            }
            catch (NullReferenceException nullex)
            {
             
            }
        }

        public Product P { get; set; }

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


        public State State
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    state = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("State"));
                        PropertyChanged(this, new PropertyChangedEventArgs("OutgoingState"));
                    }
                }
            }
        }

        public void ValidateTreatment()
        {
            ProductChanger.ChangeProductreatment(P);
            RestAccessor<Product> rap = new RestAccessor<Product>(P);
            rap.Update(P,P.QRCode);
            Navigation.PushModalAsync(new ProductDetailPage(new ProductDetailViewModel(P)));
        }

    }
}
