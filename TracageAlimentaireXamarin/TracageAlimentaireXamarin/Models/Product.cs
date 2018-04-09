﻿using System.Collections.Generic;
using TracageAlmentaireWeb.Models;

namespace Tracage.Models
{
     public class Product
    {
        public long Id { get; set; }
        public string QRCode { get; set; }

        public string Name { get; set; }

        public List<State> States { get; set; }

        public string Description { get; set; }

        public Treatment CurrentTreatment { get; set; }

        public bool IsFinal()
        {
            return this.CurrentTreatment.OutgoingState.Status == "final";
        }
    }
}
