namespace CharitySystem
{
    public abstract class SystemUser
    {
        private string userName;
        private string phoneNumber;
        private string password;
        private int age;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (value != null && value != "") userName = value;
                else throw new ArgumentException("Username can't be empty");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value != null && value.Length >= 6) password = value;
                else throw new ArgumentException("Password must be at least 6 characters");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 18) age = value;
                else throw new ArgumentException("Age must be at least 18");
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != null && value.Length == 11) phoneNumber = value;
                else throw new ArgumentException("Invalid phone number");
            }
        }

        public SystemUser(string userName, string password, int age, string phoneNumber)
        {
            UserName = userName;
            Password = password;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        public virtual bool Login(string userName, string password)
        {
            if (UserName == userName && Password == password) return true;
            return false;
        }

        public void Logout()
        {
            Console.WriteLine($"{UserName} Exit successfully");
        }
    }
}
