namespace CharitySystem
{
    public class ReceiptCashServes : IReceiptCashServes
    {
        public ReceiptCash CreateReceiptCash(Donations cashDonation)
        {
            ReceiptCash receipt = new ReceiptCash();
            receipt.IdReceipt = cashDonation.IdDonation;
            receipt.IdDonation = cashDonation.IdDonation;
            receipt.NameDonor = cashDonation.NameDonor;
            receipt.IdActivity = cashDonation.IdActivity;
            receipt.NameActivity = cashDonation.NameActivity;
            receipt.Amount = cashDonation.Amount;
            receipt.Date = DateTime.Now;
            receipt.PaymentMethod = cashDonation.PaymentMethod;
            return receipt;
        }
    }
}
