using System;
using System.Collections.Generic;
using System.Text;

namespace CharitySystem
{
     public class ViewDonar
     {
        public static List<Donor> Do = new List<Donor>();
        static int id = 1;
        public void Donar(DonationServes donationServes = null)
        {
            bool exits = true;
            do
            {
                Console.Clear();
                Console.WriteLine(" =======================================================================================================================");
                Console.WriteLine("                                                     CharitySystem       ");
                Console.WriteLine(" =======================================================================================================================");
                Console.WriteLine();
                Console.WriteLine("Donor =========================");
                Console.WriteLine("1 - Add New Donor");
                Console.WriteLine("2 - Edit Donor Details");
                Console.WriteLine("3 - Delete Donor");
                Console.WriteLine("4 - Search and Display Donor Data");
                Console.WriteLine("5 - View Donor Donation History");
                Console.WriteLine("6 - Back");
                Console.WriteLine("===================================");
                Console.Write("Enter the operation number you want: ");
                string login = Console.ReadLine();

                switch (login)
                {
                    case "1":
                        Donor don = new Donor();
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Add New Donor =========================");
                        Console.Write("plz enter name :");
                        don.Name = Console.ReadLine();

                        Console.Write("plz enter Email :");
                        don.Email = Console.ReadLine();

                        Console.Write("plz enter PhoneNumper :");
                        don.PhoneNumber = Console.ReadLine();

                        if (Do.Any(d => d.Email.Equals(don.Email)))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Error");
                            Console.WriteLine("----------------------------");
                            Console.ReadLine();
                        }
                        else
                        {
                            don.Id = id++;
                            Do.Add(don);
                            Console.WriteLine();
                            Console.WriteLine($"The donor has been successfully added. Their ID number is {don.Id}");
                            Console.WriteLine("----------------------------");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Edit Donor Details =========================");
                        Console.Write("Enter the ID you want to modify : ");
                        int UpdatId = int.Parse(Console.ReadLine());
                        if (UpdatId != null)
                        {
                            var IdUpdat = Do.FirstOrDefault(d => d.Id == UpdatId);


                            if (IdUpdat != null)
                            {

                                Console.WriteLine($"Enter the new name: {IdUpdat.Name}");
                                string NewName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(NewName)) IdUpdat.Name = NewName;

                                Console.WriteLine($"Enter the new number: {IdUpdat.PhoneNumber}");
                                string NewPhone = Console.ReadLine();
                                if (!string.IsNullOrEmpty(NewPhone)) IdUpdat.PhoneNumber = NewPhone;
                                
                                Console.WriteLine();
                                Console.WriteLine("Updated successfully.");
                                Console.WriteLine("----------------------------");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("No phone numbers were found.");
                                Console.WriteLine("----------------------------");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Delete Donor =========================");
                        Console.Write("Enter the ID to be deleted: ");
                        int IdDelet = int.Parse(Console.ReadLine());
                        if (IdDelet != null)
                        {
                            var DeletId = Do.FirstOrDefault(e => e.Id == IdDelet);

                            if (DeletId != null)
                            {
                                Do.Remove(DeletId);
                                Console.WriteLine();
                                Console.WriteLine("Donor deleted successfully!");
                                Console.WriteLine("----------------------------");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("No ID found");
                                Console.WriteLine("----------------------------");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Search =========================");
                        Console.Write("Enter the ID number you want to search for: ");
                        int IdSerch = int.Parse(Console.ReadLine());
                        if (IdSerch != null)
                        {
                            var SerchId = Do.FirstOrDefault(o => o.Id == IdSerch);


                            if (SerchId != null)
                            {
                                Console.Clear();
                                Console.WriteLine(" =======================================================================================================================");
                                Console.WriteLine("                                                     CharitySystem       ");
                                Console.WriteLine(" =======================================================================================================================");
                                Console.WriteLine();
                                Console.WriteLine(" Search =========================");
                                SerchId.Sarch();
                                Console.WriteLine("=================================");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The donor was not found.");
                                Console.WriteLine("----------------------------");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" View Donation Donor =========================");
                        Console.Write("Enter the donor's ID number to view their donation history: ");
                        int IdData = int.Parse(Console.ReadLine());
                        if (IdData != null)
                        {
                            var DataId = Do.FirstOrDefault(a => a.Id == IdData);


                            if (DataId != null)
                            {
                                Console.Clear();
                                Console.WriteLine(" =======================================================================================================================");
                                Console.WriteLine("                                                     CharitySystem       ");
                                Console.WriteLine(" =======================================================================================================================");
                                Console.WriteLine();
                                Console.WriteLine(" View Donation Donor =========================");
                                Console.WriteLine($"\n Donation History for Donor: {DataId.Name}");

                                if (donationServes != null)
                                {
                                    foreach (var donation in donationServes.ReadDonation())
                                    {
                                        if (donation.IdDonor == DataId.Id)
                                        {
                                            Console.WriteLine($"Donation ID: {donation.IdDonation}");
                                            Console.WriteLine($"Activity: {donation.NameActivity}");
                                            Console.WriteLine($"Date: {donation.Date}");

                                            if (donation.Amount > 0)
                                            {
                                                Console.WriteLine($"Amount: {donation.Amount} EGP");
                                            }
                                                

                                            if (!string.IsNullOrEmpty(donation.ItemName))
                                            {
                                                Console.WriteLine($"Item: {donation.ItemName} - Quantity: {donation.Quantity}");
                                            }

                                            Console.WriteLine("----------------------------");
                                        }
                                    }
                                }

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("The donor was not found.");
                                Console.WriteLine("----------------------------");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "6":
                        exits = false;
                        continue;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice! Please enter a number from 1 to 6.");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                        continue;
                }

            } while (exits);
        }


    }
}
