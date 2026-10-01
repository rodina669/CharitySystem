namespace CharitySystem
{
    public interface IAccountService
    {
        void UpdateBalance(decimal amount);
        decimal GetBalance();
        void ShowFinancialSummary();
        void RecordCashDonation(Donations donation);
        void RecordItemDonation(Donations donation);
    }
}
