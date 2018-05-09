using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Droid.Annotations;
using TracageAlmentaireWeb.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class StepInfoViewModel : INotifyPropertyChanged
    {
        private KeyValuePair<DateTime,Treatment> selectedTreatment;



        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public StepInfoViewModel(KeyValuePair<DateTime, Treatment> slected)
        {
            selectedTreatment = slected;
            Treatment = selectedTreatment.Value;
            RestAccessor<Step> ras = new RestAccessor<Step>(new Step());
            Step = ras.GetByIdentifier(selectedTreatment.Value.StepId);

            

        }

        public Treatment Treatment { get; set; }


        public Step Step { get; set; }

        public Process Process { get; set; }

        public KeyValuePair<DateTime, Treatment> SelectedTreatment
        {
            get { return selectedTreatment; }
            set
            {
                try
                {
                    if (selectedTreatment.Equals(value))

                        selectedTreatment = value;

                    if (this.selectedTreatment.Equals(null))
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Product"));
                    }
                }
                catch (Exception e)
                {

                }
            }

        }
    }



}
