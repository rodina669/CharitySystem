namespace CharitySystem
{
    public class DonationCashServes : IDonationCashServes
    {
        List<Donations> donations = new List<Donations>();
        DonationCashValidat valid = new DonationCashValidat();

        public void CreateDonation(Donations donation)
        {
            valid.ValidatDonation(donation);
            donations.Add(donation);
            Console.WriteLine("Create Donation Success");
        }

        public List<Donations> ReadDonation()
        {
            return donations;
        }
    }
}
