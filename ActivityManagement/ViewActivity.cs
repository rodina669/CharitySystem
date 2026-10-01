using System;
using System.Collections.Generic;
using System.Linq;

namespace CharitySystem
{
    public class ViewActivity
    {
        public static List<Activity> Activities = new List<Activity>();
        public static IActivityService Service;
        static ActivityManager manager;

        public void Activity(DonationServes sharedDonationServes = null)
        {
            if (manager == null)
            {
                IDonationServes donationServes = sharedDonationServes ?? new DonationServes();
                IActivityRepository activityRepository = new ActivityRepository();
                Service = new ActivityService(activityRepository, donationServes);
                manager = new ActivityManager("ahmed_activity", "123456", 25, "01012345678", Service);
            }

            bool isRunning = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" =======================================================================================================================");
                    Console.WriteLine("                                                     CharitySystem       ");
                    Console.WriteLine(" =======================================================================================================================");
                    Console.WriteLine();
                    Console.WriteLine(" Activity =========================");
                    Console.WriteLine("1 - Create New Activity");
                    Console.WriteLine("2 - View All Activities");
                    Console.WriteLine("3 - View Activity Details");
                    Console.WriteLine("4 - Update Activity Name / Description");
                    Console.WriteLine("5 - Set Activity Target");
                    Console.WriteLine("6 - Add Need to an Activity");
                    Console.WriteLine("7 - Remove Need from an Activity");
                    Console.WriteLine("8 - Close Activity");
                    Console.WriteLine("9 - Back");
                    Console.WriteLine("===================================");
                    Console.Write("Choose : ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Create New Activity =========================");
                        Console.Write("Activity Name : ");
                        string name = Console.ReadLine();

                        Console.Write("Description : ");
                        string description = Console.ReadLine();

                        Console.Write("Target Amount : ");
                        decimal target = decimal.Parse(Console.ReadLine());

                        Activity created = manager.CreateActivity(name, description, target);
                        if (!Activities.Any(a => a.Id == created.Id))
                            Activities.Add(created);

                        Console.WriteLine();
                        Console.WriteLine($"Activity created successfully. Activity Id = {created.Id}");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" View All Activities =========================");

                        List<Activity> activities = manager.GetAllActivities();
                        if (activities.Count == 0)
                        {
                            Console.WriteLine("No activities found.");
                        }
                        else
                        {
                            foreach (Activity a in activities)
                            {
                                decimal collected = manager.GetCollectedAmount(a.Id);
                                decimal remaining = manager.GetRemainingAmount(a.Id);
                                decimal progress = manager.GetProgressPercentage(a.Id);
                                ActivityStatus status = manager.GetActivityStatus(a.Id);

                                Console.WriteLine($"Id: {a.Id} | Name: {a.Name} | Target: {a.TargetAmount} | Collected: {collected} | Remaining: {remaining} | Progress: {progress}% | Status: {status}");
                            }
                        }

                        Console.WriteLine("===================================");
                        Console.ReadLine();
                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" View Activity Details =========================");
                        Console.Write("Activity Id : ");
                        int id = int.Parse(Console.ReadLine());

                        var a = manager.GetAllActivities().FirstOrDefault(x => x.Id == id);
                        if (a == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Activity not found.");
                            Console.WriteLine("----------------------------");
                            Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Id            : {a.Id}");
                        Console.WriteLine($"Name          : {a.Name}");
                        Console.WriteLine($"Description   : {a.Description}");
                        Console.WriteLine($"Target Amount : {a.TargetAmount} EGP");
                        Console.WriteLine($"Collected     : {manager.GetCollectedAmount(a.Id)} EGP");
                        Console.WriteLine($"Remaining     : {manager.GetRemainingAmount(a.Id)} EGP");
                        Console.WriteLine($"Progress      : {manager.GetProgressPercentage(a.Id)}%");
                        Console.WriteLine($"Status        : {manager.GetActivityStatus(a.Id)}");
                        Console.WriteLine($"Created At    : {a.CreatedAt}");

                        Console.WriteLine();
                        Console.WriteLine("Needs:");
                        if (a.Needs.Count == 0)
                        {
                            Console.WriteLine("(none)");
                        }
                        else
                        {
                            foreach (ActivityNeed need in a.Needs)
                            {
                                Console.WriteLine($"[{need.Id}] {need.Name} - Required Quantity: {need.RequiredQuantity}");
                            }
                        }

                        Console.WriteLine("===================================");
                        Console.ReadLine();
                    }
                    else if (choice == 4)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Update Activity =========================");
                        Console.Write("Activity Id : ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("New Name : ");
                        string name = Console.ReadLine();

                        Console.Write("New Description : ");
                        string description = Console.ReadLine();

                        manager.UpdateActivity(id, name, description);

                        Console.WriteLine();
                        Console.WriteLine("Activity updated successfully.");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                    }
                    else if (choice == 5)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Set Activity Target =========================");
                        Console.Write("Activity Id : ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("New Target Amount : ");
                        decimal target = decimal.Parse(Console.ReadLine());

                        manager.SetTarget(id, target);

                        Console.WriteLine();
                        Console.WriteLine("Target updated successfully.");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                    }
                    else if (choice == 6)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Add Need to Activity =========================");
                        Console.Write("Activity Id : ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Need Name : ");
                        string needName = Console.ReadLine();

                        Console.Write("Required Quantity : ");
                        int quantity = int.Parse(Console.ReadLine());

                        manager.AddNeed(id, needName, quantity);

                        Console.WriteLine();
                        Console.WriteLine("Need added successfully.");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                    }
                    else if (choice == 7)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Remove Need from Activity =========================");
                        Console.Write("Activity Id : ");
                        int id = int.Parse(Console.ReadLine());

                        var a = manager.GetAllActivities().FirstOrDefault(x => x.Id == id);
                        if (a == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Activity not found.");
                            Console.WriteLine("----------------------------");
                            Console.ReadLine();
                            continue;
                        }

                        if (a.Needs.Count == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("This activity has no needs.");
                            Console.WriteLine("----------------------------");
                            Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine();
                        foreach (ActivityNeed need in a.Needs)
                        {
                            Console.WriteLine($"[{need.Id}] {need.Name} - Required Quantity: {need.RequiredQuantity}");
                        }

                        Console.Write("Need Id to remove : ");
                        int needId = int.Parse(Console.ReadLine());

                        manager.RemoveNeed(id, needId);

                        Console.WriteLine();
                        Console.WriteLine("Need removed successfully.");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                    }
                    else if (choice == 8)
                    {
                        Console.Clear();
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine("                                                     CharitySystem       ");
                        Console.WriteLine(" =======================================================================================================================");
                        Console.WriteLine();
                        Console.WriteLine(" Close Activity =========================");
                        Console.Write("Activity Id : ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Are you sure you want to close this activity? (y/n) : ");
                        string confirm = Console.ReadLine();

                        if (confirm == "y")
                        {
                            manager.CloseActivity(id);
                            Console.WriteLine();
                            Console.WriteLine("Activity closed successfully.");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Cancelled.");
                        }

                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                    }
                    else if (choice == 9)
                    {
                        isRunning = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice Try Again");
                        Console.WriteLine("----------------------------");
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("----------------------------");
                    Console.ReadLine();
                }

            } while (isRunning);
        }
    }
}
