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
        private string message;
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

        public string Message
        {
            get { return message; }

            private set
            {
                if (message != value)
                {
                    message = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            this.message = "Welcome the the application ! ";
            ScanCommand = new Command(ScanAsync);
        }

        public MainViewModel(string message)
        {
            this.message = message;
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
                Product pdt = FindProduct(resultScan);
                if (pdt != null)
                {

                    if (pdt.IsFinal())
                        await Navigation.PushModalAsync(new ProductDetailPage(new ProductDetailViewModel(pdt)));

                    else
                        await Navigation.PushModalAsync(new ConnectionPage(new ConnectionViewModel(pdt)));

                }
                else
                {
                    this.Message = "Oups this qr doesn't belong to the label :/ ...";
                }
            }
            
        }



        public Product FindProduct(string qrCode)
        {
            Product p = new Product();
            var restAccessor = new RestAccessor<Product>(p);
            Product result = restAccessor.GetByIdentifier(qrCode);
            return (Product)result;
        }
    }
}
