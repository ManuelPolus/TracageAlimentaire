using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Tracage.DAL;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlmentaireWeb.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private Product product;
        private Dictionary<DateTime,State> datesAndStates;
        

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

        public Dictionary<DateTime,State>  DatesAndStates
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
            this.Product = p;
            List<State> states = p.States;
            List<Scan> scans = new List<Scan>();
            datesAndStates = new Dictionary<DateTime, State>();
            RestAccessor<Scan> ras = new RestAccessor<Scan>(new Scan());
            scans = ras.GetManyByIdentifier(Product.Id).ToList();
            foreach ( var state in states )
            {
                Scan matchingScan = scans.FirstOrDefault(s => s.OutgoingStateId == state.Id);
                DatesAndStates.Add(matchingScan.DateOfScan, state);
            }
        }

        
    }
}
