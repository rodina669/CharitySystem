namespace CharitySystem
{
    public class DonationReport
    {
        public int TotalDonation { get; set; }
        public decimal TotalAmount { get; set; }
        public List<DonationItemReport> Items { get; set; }
    }
}
