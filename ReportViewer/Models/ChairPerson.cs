using CharitySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharitySystem
{
    public class ChairPerson : SystemUser
    {
        public string Title { get; set; }

        public ChairPerson(string userName, string password, int age, string phoneNumber, string title)
            : base(userName, password, age, phoneNumber)
        {
            Title = title;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("User Profile:");
            Console.WriteLine("Name: " + UserName);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Phone: " + PhoneNumber);
            Console.WriteLine("Role: " + Title);
        }
    }
}
