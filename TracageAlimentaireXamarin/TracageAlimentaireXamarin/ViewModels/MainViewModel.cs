using Tracage.DAL;
using Tracage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;

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
            await scanner.ScanCodeAsync();
            IsLoading = false;
            Navigation.PushModalAsync( new ProductDetail(new ProductDetailViewModel()) );
        }
    }
}
