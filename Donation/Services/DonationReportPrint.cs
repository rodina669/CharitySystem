namespace CharitySystem
{
    public class DonationReportPrint : IDonationReportPrint
    {
        public void PrintReport(DonationReport donationReport)
        {
            Console.Clear();
            Console.WriteLine(" =======================================================================================================================");
            Console.WriteLine("                                                     CharitySystem       ");
            Console.WriteLine(" =======================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("DONATION REPORT =========================");
            Console.WriteLine($"Total Donation : {donationReport.TotalDonation}");
            Console.WriteLine($"Total Amount : {donationReport.TotalAmount}");
            Console.WriteLine("Item: ");
            if (donationReport.Items.Count == 0)
            {
                Console.WriteLine("No item donations.");
            }
            else
            {
                foreach (DonationItemReport item in donationReport.Items)
                {
                    Console.WriteLine($"Name Item : {item.ItemName}");
                    Console.WriteLine($"Quantity : {item.Quantity}");
                    Console.WriteLine();
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("=========================================");
        }
    }
}
