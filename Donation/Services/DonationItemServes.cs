namespace CharitySystem
{
    public class DonationItemServes : IDonationItemServes
    {
        List<Donations> donations = new List<Donations>();
        DonationItemValidat valid = new DonationItemValidat();

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
