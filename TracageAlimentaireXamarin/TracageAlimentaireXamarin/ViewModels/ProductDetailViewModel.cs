using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Javax.Security.Auth;
using Rg.Plugins.Popup.Extensions;
using Tracage.DAL;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Views;
using TracageAlmentaireWeb.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private Product product;
        private KeyValuePair<DateTime,Treatment> selectedTreatment;
        private Dictionary<DateTime,Treatment> datesAndStates;

        public Command DetailsCommand { get; set; }
        

        public Product Product
        {
            get { return product; }
            set
            {
                if (product != value)
                {
                    product = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Product"));
                    }
                }
            }
        }

        public Dictionary<DateTime,Treatment>  DatesAndStates
        {
            get { return datesAndStates; }
            set
            {
                if (datesAndStates != value)
                {
                    datesAndStates = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DatesAndStates"));
                    }
                }
            }
        }

        public ProductDetailViewModel(Product p)
        {
            try
            {
                this.Product = p;


                List<Treatment> treats = new List<Treatment>();
                foreach (var step in p.Process.Steps)
                {
                    treats.AddRange(step.Treatments);
                }

                datesAndStates = new Dictionary<DateTime, Treatment>();
                RestAccessor<Scan> ras = new RestAccessor<Scan>(new Scan());

                List<Scan> scans = new List<Scan>();
                scans = ras.GetManyByIdentifier(p.Id).ToList();
               
                foreach (var t in treats)
                {
                    Scan match = scans.FirstOrDefault(s => s.OutgoingStateId == t.OutgoingState.Id);
                    DatesAndStates.Add(match.DateOfScan, t);
                }

                DatesAndStates.Remove(DatesAndStates.ElementAt(DatesAndStates.Count - 1).Key);
            }
            catch (Exception e)
            {
                //process with 1 step and 1 treatment ?
            }
            
        }

        public KeyValuePair<DateTime,Treatment> SelectedTreatment
        {
            get { return selectedTreatment; }
            set
            {

                    if (selectedTreatment.Value == null ||!selectedTreatment.Value.Equals(value))
                    {
                        selectedTreatment = value;

                        if (selectedTreatment.Value != null && PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("SelectedTreatment"));
                            GoToDetails();
                        }
                    }
            }
        }


        public void GoToDetails()
        {
            Navigation.PushPopupAsync(new StepInfoPage(new StepInfoViewModel(SelectedTreatment)));
        }

        
    }
}
