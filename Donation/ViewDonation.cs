namespace CharitySystem
{
    public class ViewDonation
    {
        public void Donation(DonationServes sharedDonationServes = null, AccountManager currentAccount = null)
        {
            DonationServes donationServes = sharedDonationServes ?? new DonationServes();
            DonationCashServes donationCashServes = new DonationCashServes();
            DonationItemServes donationItemServes = new DonationItemServes();
            ReceiptItemServes receiptItemServes = new ReceiptItemServes();
            ReceiptItemPrint receiptItemPrint = new ReceiptItemPrint();
            ReceiptCashServes receiptCashServes = new ReceiptCashServes();
            ReceiptCashPrint receiptCashPrint = new ReceiptCashPrint();
            DonationReportServes donationReportServes = new DonationReportServes();
            DonationReportPrint donationReportPrint = new DonationReportPrint();
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" =======================================================================================================================");
                    Console.WriteLine("                                                     CharitySystem       ");
                    Console.WriteLine(" =======================================================================================================================");
                    Console.WriteLine();
                    Console.WriteLine("Donation =========================");
                    Console.WriteLine("1 - Add New Donation");
                    Console.WriteLine("2 - Back and Show Reports");
                    Console.WriteLine("===================================");
                    Console.Write("Choose : ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        while (true)
                        {
                            Donations donations = new Donations();
                            Console.Clear();
                            Console.WriteLine(" =======================================================================================================================");
                            Console.WriteLine("                                                     CharitySystem       ");
                            Console.WriteLine(" =======================================================================================================================");
                            Console.WriteLine();
                            Console.WriteLine("Donation =========================");
                            Console.WriteLine("1 - Cash Donation");
                            Console.WriteLine("2 - Item Donation");
                            Console.WriteLine("3 - Back");
                            Console.WriteLine("===================================");
                            Console.Write("Choose : ");
                            int choic = int.Parse(Console.ReadLine());
                            if (choic == 1)
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine("                                                     CharitySystem       ");
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine();
                                    Console.WriteLine("Cash Donation =========================");
                                    Console.WriteLine("Available Donors: ");
                                    foreach (var donor in ViewDonar.Do)
                                    {
                                        Console.WriteLine($"{donor.Id} - {donor.Name}");
                                    }
                                        

                                    Console.Write("Id Donor : ");
                                    int idDonor = int.Parse(Console.ReadLine());
                                    Donor selectedDonor = null;

                                    foreach (var donor in ViewDonar.Do)
                                    {
                                        if (donor.Id == idDonor)
                                        {
                                            selectedDonor = donor;
                                            break;
                                        }
                                    }
                                    if (selectedDonor == null)
                                    {
                                        Console.WriteLine("Donor not found.");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    string nameDonor = selectedDonor.Name;

                                    Console.WriteLine("Available Activities: ");
                                    foreach (var activity in ViewActivity.Activities)
                                    {
                                        Console.WriteLine($"{activity.Id} - {activity.Name}");
                                    }
                                        

                                    Console.Write("Id Activity : ");
                                    int idActivity = int.Parse(Console.ReadLine());
                                    Activity selectedActivity = null;

                                    foreach (var activity in ViewActivity.Activities)
                                    {
                                        if (activity.Id == idActivity)
                                        {
                                            selectedActivity = activity;
                                            break;
                                        }
                                    }
                                    if (selectedActivity == null)
                                    {
                                        Console.WriteLine("Activity not found.");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    string nameActivity = selectedActivity.Name;

                                    Console.Clear();
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine("                                                     CharitySystem       ");
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine();
                                    Console.WriteLine("Cash Donation =========================");
                                    Console.WriteLine("1 - Cash");
                                    Console.WriteLine("2 - Visa");
                                    Console.WriteLine("3 - Exit");
                                    Console.WriteLine("===================================");
                                    Console.Write("Choose : ");
                                    int choos = int.Parse(Console.ReadLine());
                                    string paymentMethod;
                                    decimal amount;

                                    if (choos == 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(" =======================================================================================================================");
                                        Console.WriteLine("                                                     CharitySystem       ");
                                        Console.WriteLine(" =======================================================================================================================");
                                        Console.WriteLine();
                                        Console.WriteLine("Item Donation =========================");
                                        Console.WriteLine("Payment Method: Cash");
                                        paymentMethod = "Cash";
                                        Console.Write("Amount : ");
                                        amount = decimal.Parse(Console.ReadLine());
                                    }
                                    else if (choos == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(" =======================================================================================================================");
                                        Console.WriteLine("                                                     CharitySystem       ");
                                        Console.WriteLine(" =======================================================================================================================");
                                        Console.WriteLine();
                                        Console.WriteLine("Item Donation =========================");
                                        Console.WriteLine("Payment Method: Visa");
                                        paymentMethod = "Visa";
                                        Console.Write("Amount : ");
                                        amount = decimal.Parse(Console.ReadLine());
                                    }
                                    else if (choos == 3)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Invalid Choice Try Again");
                                        Console.WriteLine("----------------------------");
                                        Console.ReadLine();
                                        continue;
                                    }

                                    decimal alreadyCollected = 0;
                                    foreach (Donations d in donationServes.ReadDonation())
                                    {
                                        if (d.IdActivity == selectedActivity.Id)
                                        {
                                            alreadyCollected += d.Amount;
                                        }
                                    }
                                    decimal remainingTarget = selectedActivity.TargetAmount - alreadyCollected;

                                    if (amount > remainingTarget)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Not Allowed: Amount exceeds the remaining target for this activity.");
                                        Console.WriteLine($"Remaining Target: {remainingTarget} EGP");
                                        Console.WriteLine("----------------------------");
                                        Console.ReadLine();
                                        continue;
                                    }

                                    donations.IdDonation = CharitySystem.Donation.count++;
                                    donations.NameDonor = nameDonor;
                                    donations.NameActivity = nameActivity;
                                    donations.Amount = amount;
                                    donations.Date = DateTime.Now;
                                    donations.IdDonor = idDonor;
                                    donations.IdActivity = idActivity;
                                    donations.PaymentMethod = paymentMethod;
                                    donationCashServes.CreateDonation(donations);
                                    donationServes.CreateDonation(donations);
                                    if (currentAccount != null)
                                    {
                                        currentAccount.UpdateBalanceBy(amount);
                                    }
                                    Console.Clear();
                                    receiptCashPrint.PrintReceipt(receiptCashServes.CreateReceiptCash(donations));
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(ex.Message);
                                    Console.WriteLine("----------------------------");
                                    Console.ReadLine();
                                }

                            }
                            else if (choic == 2)
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine("                                                     CharitySystem       ");
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine();
                                    Console.WriteLine("Item Donation =========================");
                                    Console.WriteLine("Available Donors:");
                                    foreach (var donor in ViewDonar.Do)
                                    {
                                        Console.WriteLine($"{donor.Id} - {donor.Name}");
                                    }
                                        

                                    Console.Write("Id Donor : ");
                                    int idDonor = int.Parse(Console.ReadLine());
                                    Donor selectedDonor = null;

                                    foreach (var donor in ViewDonar.Do)
                                    {
                                        if (donor.Id == idDonor)
                                        {
                                            selectedDonor = donor;
                                            break;
                                        }
                                    }

                                    if (selectedDonor == null)
                                    {
                                        Console.WriteLine("Donor not found.");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    string nameDonor = selectedDonor.Name;

                                    Console.WriteLine("Available Activities:");
                                    foreach (var activity in ViewActivity.Activities)
                                    {
                                        Console.WriteLine($"{activity.Id} - {activity.Name}");

                                    }
                                        

                                    Console.Write("Id Activity : ");
                                    int idActivity = int.Parse(Console.ReadLine());

                                    Activity selectedActivity = null;

                                    foreach (var activity in ViewActivity.Activities)
                                    {
                                        if (activity.Id == idActivity)
                                        {
                                            selectedActivity = activity;
                                        }
                                    }
                                    if (selectedActivity == null)
                                    {
                                        Console.WriteLine("Activity not found.");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    string nameActivity = selectedActivity.Name;

                                    Console.Clear();
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine("                                                     CharitySystem       ");
                                    Console.WriteLine(" =======================================================================================================================");
                                    Console.WriteLine();
                                    Console.WriteLine("Item Donation =========================");

                                    if (selectedActivity.Needs.Count == 0)
                                    {
                                        Console.WriteLine("This activity has no needs registered yet.");
                                        Console.WriteLine("----------------------------");
                                        Console.ReadLine();
                                        continue;
                                    }

                                    Console.WriteLine("Needed Items for this Activity:");
                                    foreach (var need in selectedActivity.Needs)
                                    {
                                        Console.WriteLine($"{need.Id} - {need.Name} (Required: {need.RequiredQuantity})");
                                    }

                                    Console.Write("Need Id : ");
                                    int needId = int.Parse(Console.ReadLine());
                                    ActivityNeed selectedNeed = null;

                                    foreach (var need in selectedActivity.Needs)
                                    {
                                        if (need.Id == needId)
                                        {
                                            selectedNeed = need;
                                            break;
                                        }
                                    }
                                    if (selectedNeed == null)
                                    {
                                        Console.WriteLine("Need not found.");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    string itemName = selectedNeed.Name;

                                    Console.Write("Quantity : ");
                                    int quantity = int.Parse(Console.ReadLine());

                                    if (quantity > selectedNeed.RequiredQuantity)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Not Allowed: Quantity exceeds the required amount for this need.");
                                        Console.WriteLine($"Required Quantity: {selectedNeed.RequiredQuantity}");
                                        Console.WriteLine("----------------------------");
                                        Console.ReadLine();
                                        continue;
                                    }

                                    donations.IdDonation = CharitySystem.Donation.count++;
                                    donations.NameDonor = nameDonor;
                                    donations.NameActivity = nameActivity;
                                    donations.ItemName = itemName;
                                    donations.Quantity = quantity;
                                    donations.Date = DateTime.Now;
                                    donations.IdDonor = idDonor;
                                    donations.IdActivity = idActivity;
                                    donationItemServes.CreateDonation(donations);
                                    donationServes.CreateDonation(donations);

                                    int remainingNeed = selectedNeed.RequiredQuantity - quantity;
                                    if (remainingNeed > 0)
                                    {
                                        selectedNeed.UpdateQuantity(remainingNeed);
                                    }
                                    else
                                    {
                                        selectedActivity.Needs.Remove(selectedNeed);
                                    }

                                    Console.Clear();
                                    receiptItemPrint.PrintReceipt(receiptItemServes.CreateReceiptItem(donations));
                                    Console.ReadLine();
                                    Console.Clear();

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(ex.Message);
                                    Console.WriteLine("----------------------------");
                                    Console.ReadLine();
                                }

                            }
                            else if (choic == 3)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid Choice Try Again");
                                Console.WriteLine("----------------------------");
                                Console.ReadLine();
                                continue;
                            }

                        }

                    }
                    else if (choice == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice Try Again");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("----------------------------");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            donationReportPrint.PrintReport(donationReportServes.ReportDonation(donationServes));

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
