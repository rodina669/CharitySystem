namespace CharitySystem
{
    public class DonationServes : IDonationServes
    {
        List<Donations> donations = new List<Donations>();

        public void CreateDonation(Donations donation)
        {
            donations.Add(donation);
        }

        public List<Donations> ReadDonation()
        {
            return donations;
        }
    }
}
