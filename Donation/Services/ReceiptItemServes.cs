namespace CharitySystem
{
    public class ReceiptItemServes : IReceiptItemServes
    {
        public ReceiptItem CreateReceiptItem(Donations itemDonation)
        {
            ReceiptItem receipt = new ReceiptItem();
            receipt.IdReceipt = itemDonation.IdDonation;
            receipt.IdDonation = itemDonation.IdDonation;
            receipt.NameDonor = itemDonation.NameDonor;
            receipt.IdActivity = itemDonation.IdActivity;
            receipt.NameActivity = itemDonation.NameActivity;
            receipt.ItemName = itemDonation.ItemName;
            receipt.Quantity = itemDonation.Quantity;
            receipt.Date = DateTime.Now;
            return receipt;
        }
    }
}
