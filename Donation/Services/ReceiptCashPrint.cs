namespace CharitySystem
{
    public class ReceiptCashPrint : IReceiptCashPrint
    {
        public void PrintReceipt(ReceiptCash receipt)
        {
            Console.Clear();
            Console.WriteLine(" =======================================================================================================================");
            Console.WriteLine("                                                     CharitySystem       ");
            Console.WriteLine(" =======================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("RECEIPT =========================");
            Console.WriteLine($"Receipt Id : {receipt.IdReceipt}");
            Console.WriteLine($"Donor Name : {receipt.NameDonor}");
            Console.WriteLine($"Activity Name : {receipt.NameActivity}");
            Console.WriteLine($"Amount : {receipt.Amount}");
            Console.WriteLine($"Date : {receipt.Date}");
            Console.WriteLine($"Payment Method : {receipt.PaymentMethod}");
            Console.WriteLine($"Donation Type : {receipt.DonationType}");
            Console.WriteLine("==================================");
        }
    }
}
