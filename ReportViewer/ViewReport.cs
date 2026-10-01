using System;
using System.Collections.Generic;
using System.Text;

namespace CharitySystem
{
    public class ViewReport
    {
        public void Report(AccountManager currentAccount, DonationServes sharedDonationService)
        {

            DonationServes donationService = sharedDonationService;
            DonationReportServes donationReportService = new DonationReportServes();
            IActivityService activityService = ViewActivity.Service;

            IChairPersonService chairService = new ChairPersonService(
                donationService, donationReportService, activityService);

            ChairPerson currentChair = new ChairPerson(currentAccount.UserName, currentAccount.Password, currentAccount.Age, currentAccount.PhoneNumber, currentAccount.Qualification);

            bool isRunning = true;

            do
            {
                Console.Clear();
                Console.WriteLine(" =======================================================================================================================");
                Console.WriteLine("                                                     CharitySystem       ");
                Console.WriteLine(" =======================================================================================================================");
                Console.WriteLine();
                Console.WriteLine(" Chairperson Menu =========================");
                Console.WriteLine("1. View Financial Report");
                Console.WriteLine("2. View Donation Report");
                Console.WriteLine("3. Review Activities");
                Console.WriteLine("4. Review Receipt by ID");
                Console.WriteLine("5. Review All Donations");
                Console.WriteLine("6. User Profile");
                Console.WriteLine("7. Back");
                Console.WriteLine("===================================");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" View Financial Report =========================");
                        chairService.ViewFinancialReport();
                        Console.WriteLine("================================================");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" View Donation Report ==========================");
                        chairService.ViewDonationReport();
                        Console.WriteLine("================================================");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Review Activities =============================");
                        chairService.ReviewActivities();
                        Console.WriteLine("================================================");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Review Receipt by ID =========================");
                        Console.Write("Enter Receipt ID: ");
                        string rInput = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Review Receipt by ID =========================");
                        if (int.TryParse(rInput, out int receiptId))
                        {
                            chairService.ReviewReceipt(receiptId);
                            Console.WriteLine("===========================================");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a valid number");
                            Console.WriteLine("----------------------------");
                            Console.ReadLine();
                        }
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Review All Donations =========================");
                        chairService.ReviewDonations();
                        Console.WriteLine("===========================================");
                        Console.ReadLine();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" User Profile =========================");
                        currentChair.DisplayInfo();
                        Console.WriteLine("===========================================");
                        Console.ReadLine();
                        break;

                    case "7":
                        currentChair.Logout();
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Wrong choice, try again");
                        Console.WriteLine("-----------------------------");
                        Console.ReadLine();
                        break;
                }

            } while (isRunning);
        }
    }
}
