
namespace CharitySystem
{
    public interface IDonationServes
    {
        void CreateDonation(Donations donations);
        List<Donations> ReadDonation();
    }
}
