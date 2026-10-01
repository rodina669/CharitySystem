namespace CharitySystem
{
    public class DonationReportServes : IDonationReport
    {
        public DonationReport ReportDonation(DonationServes donationServes)
        {
            DonationReport report = new DonationReport();
            report.TotalDonation = donationServes.ReadDonation().Count;
            report.TotalAmount = donationServes.ReadDonation().Sum(x => x.Amount);
            report.Items = new List<DonationItemReport>();

            foreach (Donations item in donationServes.ReadDonation())
            {
                if (string.IsNullOrWhiteSpace(item.ItemName))
                {
                    continue;
                }
                else 
                {
                    DonationItemReport itemReport = new DonationItemReport();
                    itemReport.ItemName = item.ItemName;
                    itemReport.Quantity = item.Quantity;
                    report.Items.Add(itemReport);
                }
               
            }
            return report;
        }
    }
}
