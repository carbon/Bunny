#nullable disable

namespace BunnyCdn
{
    public sealed class BillingSummary
    {
        public decimal Balance { get; init; }

        public decimal ThisMonthCharges { get; init; }

        public BillingRecord[] BillingRecords { get; init; }

        public decimal MonthlyChargesStorage { get; init; }

        public decimal MonthlyChargesEUTraffic { get; init; }

        public decimal MonthlyChargesUSTraffic { get; init; }

        public decimal MonthlyChargesASIATraffic { get; init; }

        public decimal MonthlyChargesSATraffic { get; init; }
    }
}