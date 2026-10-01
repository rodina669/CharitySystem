namespace CharitySystem
{
    public class ItemDonation : Donation
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public override string DonationType { get { return "Item"; } }
    }
}
