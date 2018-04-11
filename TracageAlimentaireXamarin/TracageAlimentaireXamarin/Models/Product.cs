using System;
using System.Collections.Generic;
using System.Linq;
using TracageAlmentaireWeb.Models;

namespace Tracage.Models
{
     public class Product
    {

        public Product()
        {
            this.CurrentTreatment = Process.Steps.ElementAt(0).Treatments.ElementAt(0);
            QRCode = String.IsNullOrEmpty(QRCode)? this.Id+this.GetType().Name : QRCode;
        }

        public long Id { get; set; }
        public string QRCode { get; set; }

        public string Name { get; set; }

        public List<State> States { get; set; }

        public string Description { get; set; }

        public Process Process { get; set; }

        public Treatment CurrentTreatment { get; set; }

        public bool IsFinal()
        {
            try
            {
                return this.CurrentTreatment.OutgoingState.Status == "final";
            }
            catch (NullReferenceException nullex)
            {
                return false;
            }
            
        }
    }
}
