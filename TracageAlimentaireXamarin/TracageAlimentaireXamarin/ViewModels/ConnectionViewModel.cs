using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;
using System.Windows.Input;
using Tracage.Models;
using Tracage.ViewModels;
using Tracage.Views;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Views;
using TracageAlmentaireWeb.BL.Components;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ConnectionViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        private string password;
        private Product scannedProduct;

        public ConnectionViewModel(Product p)
        {
            LoginCommand = new Command(Login);
            this.scannedProduct = p;

        }

        public INavigation Navigation { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                    }
                }
            }

        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                    }
                }
            }

        }

        

        public async void Login()
        {
            //RestAccessor<User> ra = new RestAccessor<User>(typeof(User));
            //User loginUser = ra.GetByIdentifier(Email);
            //if(PasswordHasher.CheckPassword(Password, loginUser.Password))
           await Navigation.PushModalAsync(new NextTreatmentValidationPage(new NextTreatmentValidationViewModel(scannedProduct)));
        }

    }
}
