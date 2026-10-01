
namespace CharitySystem
{
    public interface IDonationItemServes
    {
        void CreateDonation(Donations donation);
        List<Donations> ReadDonation();
    }
}
