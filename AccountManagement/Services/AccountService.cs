namespace CharitySystem
{
    public class AccountService : IAccountService
    {
        private AccountManager accountManager;

        private DonationServes donationServes;
        private DonationCashServes donationCashServes;
        private DonationItemServes donationItemServes;

        private ReceiptCashServes receiptCashServes;
        private ReceiptCashPrint receiptCashPrint;

        private ReceiptItemServes receiptItemServes;
        private ReceiptItemPrint receiptItemPrint;

        public AccountService(AccountManager accountManager, DonationServes donationServes, DonationCashServes donationCashServes,
            DonationItemServes donationItemServes, ReceiptCashServes receiptCashServes, ReceiptCashPrint receiptCashPrint,
            ReceiptItemServes receiptItemServes, ReceiptItemPrint receiptItemPrint)
        {
            this.accountManager = accountManager;
            this.donationServes = donationServes;
            this.donationCashServes = donationCashServes;
            this.donationItemServes = donationItemServes;
            this.receiptCashServes = receiptCashServes;
            this.receiptCashPrint = receiptCashPrint;
            this.receiptItemServes = receiptItemServes;
            this.receiptItemPrint = receiptItemPrint;
        }

        public void UpdateBalance(decimal amount)
        {
            accountManager.UpdateBalanceBy(amount);
        }

        public decimal GetBalance()
        {
            return accountManager.Balance;
        }

        public void ShowFinancialSummary()
        {
            Console.WriteLine("------------------- Financial Summary -------------------");
            Console.WriteLine($"Current Balance: {accountManager.Balance} EGP");
            Console.WriteLine($"Total Donations: {donationServes.ReadDonation().Count}");

            decimal totalCash = 0;
            foreach (Donations donation in donationServes.ReadDonation())
            {
                totalCash += donation.Amount;
            }

            Console.WriteLine($"Total Cash Donations: {totalCash} EGP");

            Dictionary<string, int> itemTotals = new Dictionary<string, int>();
            foreach (Donations donation in donationServes.ReadDonation())
            {
                if (!string.IsNullOrEmpty(donation.ItemName))
                {
                    if (itemTotals.ContainsKey(donation.ItemName))
                    {
                        itemTotals[donation.ItemName] += donation.Quantity;
                    }
                    else
                    {
                        itemTotals[donation.ItemName] = donation.Quantity;
                    }
                }
            }

            Console.WriteLine("Total Item Donations:");
            if (itemTotals.Count == 0)
            {
                Console.WriteLine("No item donations yet.");
            }
            else
            {
                foreach (KeyValuePair<string, int> item in itemTotals)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }
        }

        public void RecordCashDonation(Donations donation)
        {
            donationCashServes.CreateDonation(donation);
            donationServes.CreateDonation(donation);

            ReceiptCash receipt = receiptCashServes.CreateReceiptCash(donation);
            receiptCashPrint.PrintReceipt(receipt);

            UpdateBalance(donation.Amount);
        }

        public void RecordItemDonation(Donations donation)
        {
            donationItemServes.CreateDonation(donation);
            donationServes.CreateDonation(donation);

            ReceiptItem receipt = receiptItemServes.CreateReceiptItem(donation);
            receiptItemPrint.PrintReceipt(receipt);
        }
    }
}
