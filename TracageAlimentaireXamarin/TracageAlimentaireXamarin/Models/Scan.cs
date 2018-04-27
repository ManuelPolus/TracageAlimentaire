using System;

namespace TracageAlmentaireWeb.Models
{
    public class Scan
    {
        public Scan()
        {

        }
        public Scan(long productId,long treatmentId,long outgoingStateId)
        {
            ProductId = productId;
            UserId = 31415;
            TreatmentId = treatmentId;
            OutgoingStateId = outgoingStateId;
            DateOfScan = DateTime.Now;
        }

        public long UserId { get; set; }

        public long ProductId { get; set; }

        public long TreatmentId { get; set; }

        public long OutgoingStateId { get; set; }

        public DateTime DateOfScan { get; set; }

    }
}