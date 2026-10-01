namespace CharitySystem
{
    public interface IDonationCashServes
    {
        void CreateDonation(Donations donation);
        List<Donations> ReadDonation();
    }
}
