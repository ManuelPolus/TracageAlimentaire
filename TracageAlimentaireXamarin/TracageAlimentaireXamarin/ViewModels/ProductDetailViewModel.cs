using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Tracage.DAL;
using Tracage.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private Product product;

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

        public ProductDetailViewModel(Product p)
        {
            this.Product = p;
        }

        
    }
}
