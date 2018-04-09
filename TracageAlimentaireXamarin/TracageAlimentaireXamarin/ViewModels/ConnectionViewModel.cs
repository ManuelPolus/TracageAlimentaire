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
using TracageAlmentaireWeb.BL.Components;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ConnectionViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        private string password;

        public ConnectionViewModel()
        {
            LoginCommand = new Command(Login);
            
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

        public void Login()
        {
            RestAccessor<User> ra = new RestAccessor<User>(typeof(User));
            User loginUser = ra.GetByIdentifier(Email);
            PasswordHasher.CheckPassword(Password, loginUser.Password);
            App.Current.MainPage = new MainPage(new MainViewModel());
        }

    }
}
