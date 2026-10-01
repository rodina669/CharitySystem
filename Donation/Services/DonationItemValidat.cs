using System.Text.RegularExpressions;

namespace CharitySystem
{
    public class DonationItemValidat : IDonationItemValidat
    {
        public void ValidatDonation(Donations donation)
        {
            if (donation == null)
                throw new Exception("Donation Empty");
            else if (donation.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");
            else if (string.IsNullOrEmpty(donation.ItemName))
                throw new Exception("Invalid Item Name");
            else if (donation.IdDonor <= 0)
                throw new Exception("Invalid Id Donor ");
            else if (donation.IdActivity <= 0)
                throw new Exception("Invalid Id Activity ");
            else if (string.IsNullOrEmpty(donation.NameDonor) || !Regex.IsMatch(donation.NameDonor, @"^[\p{L}\p{N} ]+$"))
                throw new Exception("Invalid Name Donor ");
            else if (string.IsNullOrEmpty(donation.NameActivity) || !Regex.IsMatch(donation.NameActivity, @"^[\p{L}\p{N} ]+$"))
                throw new Exception("Invalid Name Activity ");
        }
    }
}
