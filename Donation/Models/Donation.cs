namespace CharitySystem
{
    public class Donation
    {
        public static int count = 1;
        public int IdDonation { get; set; }
        public int IdDonor { get; set; }
        public string NameDonor { get; set; }
        public int IdActivity { get; set; }
        public string NameActivity { get; set; }
        public DateTime Date { get; set; }
        public virtual string DonationType { get; }
    }
}
