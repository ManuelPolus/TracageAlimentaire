using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Rg.Plugins.Popup.Extensions;
using Tracage.Models;
using TracageAlimentaireXamarin.BL.Components;
using TracageAlimentaireXamarin.Models;
using TracageAlimentaireXamarin.Views;
using TracageAlmentaireWeb.Models;
using Xamarin.Forms;

namespace TracageAlimentaireXamarin.ViewModels
{
    public class NextTreatmentValidationViewModel : INotifyPropertyChanged
    {

        private Treatment treatmentToValidate;
        private State state;

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public Command ValidateCommand { get; set; }

        public NextTreatmentValidationViewModel(Product p, User loginUser)
        {
            try
            {
                ValidateCommand = new Command(ValidateTreatment);
                this.P = p;

                this.treatmentToValidate = ProductChanger.FindNextTreatment(p);
                RestAccessor<UserScanRights> raur = new RestAccessor<UserScanRights>(new UserScanRights());
                List<UserScanRights> ulist = new List<UserScanRights>();
                ulist = raur.GetManyByIdentifier(loginUser.CurrentRole_Id).ToList();
                var match = ulist.Find(u => u.TreatmentId == treatmentToValidate.Id);
                if  (match == null)
                {
                    Navigation.PushPopupAsync(new AccessDenied(new AccessViewModel()));
                }
            }
            catch (Exception nullex)
            {
             
            }
        }

        public Product P { get; set; }

        public Treatment TreatmentToValidate
        {
            get { return treatmentToValidate; }
            set
            {
                if (treatmentToValidate != value)
                {
                    treatmentToValidate = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("TreatmentToValidate"));
                    }
                }
            }
        }


        public State State
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    state = value;

                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("State"));
                        PropertyChanged(this, new PropertyChangedEventArgs("OutgoingState"));
                    }
                }
            }
        }

        public void ValidateTreatment()
        {
            
            ProductChanger.ChangeProductreatment(P);
            RestAccessor<Product> rap = new RestAccessor<Product>(P);
            rap.Update(P,P.QRCode);
            
            Navigation.PushModalAsync(new ProductDetailPage(new ProductDetailViewModel(P)));
        }

    }
}
