namespace CharitySystem
{
    public class ReportViewer
    {
        public void ShowFinancialReport(decimal totalAmount, List<Activity> activities)
        {
            Console.WriteLine("Financial Report:");
            Console.WriteLine("Total Revenues: " + totalAmount + " EGP");

            decimal totalTarget = 0;
            if (activities != null)
            {
                foreach (Activity act in activities)
                {
                    totalTarget = totalTarget + act.TargetAmount;
                }
            }
            Console.WriteLine("Target Planned: " + totalTarget + " EGP");

            decimal remaining = 0;
            if (totalTarget > totalAmount)
            {
                remaining = totalTarget - totalAmount;
            }
            Console.WriteLine("Remaining Needed: " + remaining + " EGP");
        }

        public void ShowDonationReport(DonationReport report)
        {
            Console.WriteLine("Donation Report:");
            if (report != null)
            {
                Console.WriteLine("Total Donations: " + report.TotalDonation);
                Console.WriteLine("Total Amount: " + report.TotalAmount + " EGP");
                Console.WriteLine("Items Donated:");
                if (report.Items != null && report.Items.Count > 0)
                {
                    foreach (DonationItemReport item in report.Items)
                    {
                        if (!string.IsNullOrEmpty(item.ItemName))
                        {
                            Console.WriteLine(item.ItemName + " - Qty: " + item.Quantity);
                        }
                    }
                }
            }
        }

        public void ShowActivities(List<Activity> activities, IActivityService activityService)
        {
            Console.WriteLine("Activities Status:");
            if (activities != null && activities.Count > 0)
            {
                foreach (Activity act in activities)
                {
                    decimal progress = 0;
                    decimal collected = 0;
                    if (activityService != null)
                    {
                        progress = activityService.GetProgressPercentage(act.Id);
                        collected = activityService.GetCollectedAmount(act.Id);
                    }
                    Console.WriteLine("ID: " + act.Id + " | Name: " + act.Name + " | Target: " + act.TargetAmount + " | Collected: " + collected + " | Progress: " + progress + "% | Status: " + act.Status);
                }
            }
            else
            {
                Console.WriteLine("No activities found");
            }
        }

        public void ShowDonations(List<Donations> donations)
        {
            Console.WriteLine("Donations List:");
            if (donations != null && donations.Count > 0)
            {
                foreach (Donations d in donations)
                {
                    string details;
                    if (!string.IsNullOrEmpty(d.ItemName))
                    {
                        details = "Item: " + d.ItemName + " (" + d.Quantity + ")";
                    }
                    else
                    {
                        details = "Amount: " + d.Amount + " (" + d.PaymentMethod + ")";
                    }
                    Console.WriteLine("ID: " + d.IdDonation + " | Donor: " + d.NameDonor + " | Activity: " + d.NameActivity + " | " + details);
                }
            }
            else
            {
                Console.WriteLine("No donations found");
            }
        }

        public void ShowReceipt(Donations donation)
        {
            Console.WriteLine("Receipt Details:");
            if (donation != null)
            {
                Console.WriteLine("Donation ID: " + donation.IdDonation);
                Console.WriteLine("Donor Name: " + donation.NameDonor);
                Console.WriteLine("Activity Name: " + donation.NameActivity);
                Console.WriteLine("Date: " + donation.Date);

                if (!string.IsNullOrEmpty(donation.ItemName))
                {
                    Console.WriteLine("Item: " + donation.ItemName + " | Quantity: " + donation.Quantity);
                }
                else
                {
                    Console.WriteLine("Amount: " + donation.Amount + " EGP | Payment: " + donation.PaymentMethod);
                }
            }
            else
            {
                Console.WriteLine("Receipt not found!");
            }
        }
    }
}
