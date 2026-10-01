namespace CharitySystem
{
    public class CashDonation : Donation
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public override string DonationType { get { return "Money"; } }
    }
}
