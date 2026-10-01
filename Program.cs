using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
namespace CharitySystem
{
    public class Program
    {
        

        static void Main()
        {
            DonationServes donationServes = new DonationServes();
             List<AccountManager> accounts = new List<AccountManager>
            {
                new AccountManager("Admin", "Admin123456", 30, "01012345678", "Admin")
            };
             AccountManager currentAccount =null;

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" =======================================================================================================================");
                    Console.WriteLine("                                                     CharitySystem       ");
                    Console.WriteLine(" =======================================================================================================================");
                    Console.WriteLine();
                    Console.WriteLine("Welcome =========================");
                    Console.WriteLine("1 - Login");
                    Console.WriteLine("2 - Signin");
                    Console.WriteLine("3 - Exit ");
                    Console.WriteLine("=================================");
                    Console.Write("Choice : ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine("Login =======================================");
                        Console.WriteLine("UserName: Admin || Password: Admin123456");
                        Console.WriteLine("=============================================");
                        Console.Write("UserName: ");
                        string name = Console.ReadLine();
                        Console.Write("Password: ");
                        String password = Console.ReadLine();
                        currentAccount = null;
                        foreach (var account in accounts)
                        {
                            if (account.Login(name, password))
                            {
                                currentAccount = account;
                                break;
                            }
                        }
                        if (currentAccount != null)
                        {
                            while (true)
                            {
                                int itemCount = 0;
                                foreach (Donations donation in donationServes.ReadDonation())
                                {
                                    if (!string.IsNullOrEmpty(donation.ItemName))
                                    {
                                        itemCount += donation.Quantity;
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine(" =======================================================================================================================");
                                Console.WriteLine("                                                     CharitySystem       ");
                                Console.WriteLine(" =======================================================================================================================");
                                Console.WriteLine();
                                Console.WriteLine($"Hello {currentAccount.UserName} | Balance: {currentAccount.Balance} EGP | Items: {itemCount} ");
                                Console.WriteLine("=============================================");
                                Console.WriteLine($"Items: {itemCount}");

                                Console.WriteLine("1 - Donar");
                                Console.WriteLine("2 - Activity");
                                Console.WriteLine("3 - Donation");
                                Console.WriteLine("4 - Report");
                                Console.WriteLine("5 - Logout");
                                Console.WriteLine("=============================================");
                                Console.Write("Choice : ");
                                int choic = int.Parse(Console.ReadLine());
                                if (choic == 1)
                                {
                                    ViewDonar donar = new ViewDonar();
                                    donar.Donar(donationServes);
                                }
                                else if (choic == 2)
                                {
                                    ViewActivity activity = new ViewActivity();
                                    activity.Activity(donationServes);
                                }
                                else if (choic == 3)
                                {
                                    ViewDonation donation = new ViewDonation();
                                    donation.Donation(donationServes, currentAccount);

                                }
                                else if (choic == 4)
                                {
                                    ViewReport report = new ViewReport();
                                    report.Report(currentAccount, donationServes);
                                }
                                else if (choic == 5)
                                {
                                    currentAccount = null;
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Choice Try Again");
                                    Console.WriteLine("-----------------------------");
                                    Console.WriteLine();
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid UserName and Password");
                            Console.WriteLine("--------------------------------");
                            Console.ReadLine();

                        }

                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine("Signin =========================");
                        ViewAccount account = new ViewAccount();
                        AccountManager newAccount = account.Account();
                        accounts.Add(newAccount);

                    }
                    else if (choice == 3)
                    {
                        currentAccount?.Logout();
                        break;
                        
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice Try Again");
                        Console.WriteLine("-----------------------------");
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

        }

    }
}