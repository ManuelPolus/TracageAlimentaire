using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                p.States = new List<State>();
                RestAccessor<Treatment> rat = new RestAccessor<Treatment>(new Treatment());
                p.CurrentTreatment = rat.GetByIdentifier(2);
                this.treatmentToValidate = ProductChanger.FindNextTreatment(p);

            }
            catch (NullReferenceException nullex)
            {
                this.treatmentToValidate = new Treatment();
                treatmentToValidate.Name = "Tuage";
                treatmentToValidate.Description = "la banane est sauvagement assassinée";
                State = new State { Status = "si toi aussi t'es une ppetite banane comme moi t'as intérêt à courir vite si tu veux pas finir dans mariokart." };
                treatmentToValidate.OutgoingState = this.State;

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
            rap.Update(P);
            Navigation.PushModalAsync(new ProductDetailPage(new ProductDetailViewModel(P)));
        }

    }
}
