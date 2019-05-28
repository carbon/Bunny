#nullable disable

using System;

namespace BunnyCdn
{
    public class BillingRecord
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }
  
        // e.g. billing@company.com
        public string Payer { get; set; }

        public string PaymentId { get; set; }

        public DateTime Timestamp { get; set; }

        public bool InvoiceAvailable { get; set; }

        public BillingType Type { get; set; }
    }
}