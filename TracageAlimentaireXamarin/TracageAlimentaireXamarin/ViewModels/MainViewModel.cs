using Tracage.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.ViewModels;
using TracageAlimentaireXamarin.Views;

namespace Tracage.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private bool isLoading;

        public Command ScanCommand { get; set; }

        public INavigation Navigation { get; set; }

        public bool IsLoading
        {
            get { return isLoading; }

            private set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("IsLoading"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            ScanCommand = new Command(ScanAsync);
        }


        private async void ScanAsync()
        {
            IsLoading = true;
            SharedScanner scanner = new SharedScanner();
            var resultScan = await scanner.ScanCodeAsync();
            IsLoading = false;
            if (resultScan != null)
            {

                var pdt =FindProduct(resultScan);
                await Navigation.PushModalAsync(new ProductDetail(new ProductDetailViewModel(pdt)));
            }
                
        }

        public Produit FindProduct(string qrCode)
        {
            var restAccessor = new RestAccessor(typeof(Produit));
            var result = restAccessor.GetByIdentifier(qrCode);
            restAccessor.DefineType(typeof(Utilisateur));
            List<Utilisateur> users = new List<Utilisateur>();
            users = restAccessor.GetAsList<Utilisateur>().ToList();
            
            return (Produit)result;
        }
    }
}
