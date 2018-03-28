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
        private string qrCode;

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Produit Product { get; set; }

        public ProductDetailViewModel(string qrCode)
        {
            this.qrCode = qrCode;
            FindProduct();
        }

        public void FindProduct()
        {
            RestClient<Produit> client = new RestClient<Produit>("/Produits");
            var result = client.GetItemAsync(qrCode);
            Product = (Produit) result;
        }
    }
}
