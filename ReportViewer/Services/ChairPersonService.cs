namespace CharitySystem
{
    public class ChairPersonService : IChairPersonService
    {
        private readonly IDonationServes donationService;
        private readonly IDonationReport donationReportService;
        private readonly IActivityService activityService;
        private readonly ReportViewer viewer;

        public ChairPersonService(IDonationServes dService, IDonationReport rService, IActivityService aService)
        {
            donationService = dService;
            donationReportService = rService;
            activityService = aService;
            viewer = new ReportViewer();
        }
        public void ViewFinancialReport()
        {
            List<Donations> list = null;
            if (donationService != null)
            {
                list = donationService.ReadDonation();
            }

            decimal total = 0;
            if (list != null)
            {
                foreach (Donations d in list)
                {
                    total = total + d.Amount;
                }
            }

            List<Activity> acts = null;
            if (activityService != null)
            {
                acts = activityService.GetAllActivities();
            }

            viewer.ShowFinancialReport(total, acts);
        }
        public void ViewDonationReport()
        {
            if (donationReportService != null && donationService != null)
            {
                DonationReport report = donationReportService.ReportDonation((DonationServes)donationService);
                viewer.ShowDonationReport(report);
            }
        }

        public void ReviewActivities()
        {
            List<Activity> acts = null;
            if (activityService != null)
            {
                acts = activityService.GetAllActivities();
            }
            viewer.ShowActivities(acts, activityService);
        }

        public void ReviewDonations()
        {
            List<Donations> list = null;
            if (donationService != null)
            {
                list = donationService.ReadDonation();
            }
            viewer.ShowDonations(list);
        }
        public void ReviewReceipt(int receiptId)
        {
            List<Donations> list = donationService?.ReadDonation();

            Donations found = null;
            if (list != null)
            {
                foreach (Donations d in list)
                {
                    if (d.IdDonation == receiptId)
                    {
                        found = d;
                        break;
                    }
                }
            }
            viewer.ShowReceipt(found);
        }
    }
}
