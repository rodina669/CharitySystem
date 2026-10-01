using System;
using System.Collections.Generic;
using System.Text;

namespace CharitySystem
{

    public class ViewAccount
    {
        public AccountManager Account()
        {
            static AccountManager CreateAccountManager()
            {
                AccountManager m = null;

                while (m == null)
                {
                    try
                    {
                        string un = Inputs.ReadString("Username: ");
                        string pass = Inputs.ReadString("Password: ");
                        int age = Inputs.ReadInt("Age: ");
                        string phn = Inputs.ReadString("Phone Number: ");
                        string qual = Inputs.ReadString("Role: ");

                        m = new AccountManager(un, pass, age, phn, qual);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}. Please enter all the data again.\n");
                    }
                }
                return m;
            }

            AccountManager m = CreateAccountManager();

            DonationServes donationServes = new DonationServes();
            DonationCashServes donationCashServes = new DonationCashServes();
            DonationItemServes donationItemServes = new DonationItemServes();

            ReceiptCashServes receiptCashServes = new ReceiptCashServes();
            ReceiptCashPrint receiptCashPrint = new ReceiptCashPrint();

            ReceiptItemServes receiptItemServes = new ReceiptItemServes();
            ReceiptItemPrint receiptItemPrint = new ReceiptItemPrint();

            IAccountService accountService = new AccountService(m, donationServes, donationCashServes, donationItemServes, receiptCashServes, receiptCashPrint, receiptItemServes, receiptItemPrint);

            Console.WriteLine($"Balance: {accountService.GetBalance()} EGP");

            accountService.ShowFinancialSummary();

            return m;
        }
    }
}
