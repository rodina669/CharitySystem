namespace CharitySystem
{
    public class Donations
    {
        internal string paymentMethod;

        public int IdDonation { get; set; }
        public int IdDonor { get; set; }
        public string NameDonor { get; set; }
        public int IdActivity { get; set; }
        public string NameActivity { get; set; }
        public DateTime Date { get; set; }
        public virtual string DonationType { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
