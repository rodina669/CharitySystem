namespace CharitySystem
{
    public interface IChairPersonService
    {
        void ViewFinancialReport();
        void ViewDonationReport();
        void ReviewActivities();
        void ReviewDonations();
        void ReviewReceipt(int receiptId);
    }
}
