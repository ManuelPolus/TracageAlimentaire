using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Tracage.DAL;
using Tracage.Models;
using TracageAlmentaireWeb.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private Product product;
        private ObservableCollection<State> observableStates;

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

        public ObservableCollection<State>  ObservableStates
        {
            get { return observableStates; }
            set
            {
                if (observableStates != value)
                {
                    observableStates = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ObservableStates"));
                    }
                }
            }
        }

        public ProductDetailViewModel(Product p)
        {
            this.Product = p;
            this.ObservableStates = new ObservableCollection<State>(p.States);
        }

        
    }
}
