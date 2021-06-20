#nullable disable

using System;

namespace BunnyCdn
{
    public sealed class BillingRecord
    {
        public long Id { get; init; }

        public decimal Amount { get; init; }
  
        // e.g. billing@company.com
        public string Payer { get; init; }

        public string PaymentId { get; init; }

        public DateTime Timestamp { get; init; }

        public bool InvoiceAvailable { get; init; }

        public BillingType Type { get; init; }
    }
}