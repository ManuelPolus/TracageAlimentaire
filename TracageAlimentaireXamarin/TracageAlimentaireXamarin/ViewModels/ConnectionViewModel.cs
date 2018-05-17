﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Views;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class ConnectionViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        private string password;
        private Product scannedProduct;
        private string errorMessage;

        public ConnectionViewModel(Product p)
        {
            LoginCommand = new Command(Login);
            this.scannedProduct = p;
            this.ErrorMessage = String.Empty;
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

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                    }
                }
            }

        }


        public async void Login()
        {
            try
            {
                RestAccessor<User> ra = new RestAccessor<User>(new User());
                User loginUser = ra.GetByIdentifier(email);
                

                if (PasswordChecker.CheckPassord(Password, loginUser))
                {
                    if (scannedProduct.Process == null)
                        await Navigation.PushModalAsync(new ProcessSelectionPage(new ProcessSelectionViewModel(scannedProduct, loginUser)));

                    else
                        await Navigation.PushModalAsync(new NextTreatmentValidationPage(new NextTreatmentValidationViewModel(scannedProduct,loginUser)));

                }
                else
                    errorMessage = "identifiants erronnés";

            }
            catch (NullReferenceException nullex)
            {
                ErrorMessage = "Veuillez insérer vos identifiants";
            }

        }

    }
}
