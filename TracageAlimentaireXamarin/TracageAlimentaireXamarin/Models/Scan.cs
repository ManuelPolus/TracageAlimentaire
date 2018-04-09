using System;

namespace TracageAlmentaireWeb.Models
{
    public class Scan
    {
        public long UserId { get; set; }

        public long TreatmentId { get; set; }

        public DateTime DateOfScan { get; set; }

    }
}