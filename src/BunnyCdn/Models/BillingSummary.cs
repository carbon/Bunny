#nullable disable

namespace BunnyCdn
{
    public class BillingSummary
    {
        public decimal Balance { get; set; }

        public decimal ThisMonthCharges { get; set; }

        public BillingRecord[] BillingRecords { get; set; }

        public decimal MonthlyChargesStorage { get; set; }

        public decimal MonthlyChargesEUTraffic { get; set; }

        public decimal MonthlyChargesUSTraffic { get; set; }

        public decimal MonthlyChargesASIATraffic { get; set; }

        public decimal MonthlyChargesSATraffic { get; set; }
    }
}