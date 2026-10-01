namespace CharitySystem
{
    public class ReceiptItemPrint : IReceiptItemPrint
    {
        public void PrintReceipt(ReceiptItem receipt)
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
            Console.WriteLine($"Item Name : {receipt.ItemName}");
            Console.WriteLine($"Quantity : {receipt.Quantity}");
            Console.WriteLine($"Date : {receipt.Date}");
            Console.WriteLine($"Donation Type : {receipt.DonationType}");
            Console.WriteLine("==================================");
        }
    }
}
