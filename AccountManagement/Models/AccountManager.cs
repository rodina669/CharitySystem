namespace CharitySystem
{
    public class AccountManager : SystemUser
    {
        public string Qualification { get; set; }
        public decimal Balance { get; private set; }

        public AccountManager(string userName, string password, int age, string phoneNumber, string qualification, decimal balance = 0) : base(userName, password, age, phoneNumber)
        {
            Qualification = qualification;
            Balance = balance;
        }

        public void Communicate()
        {
            Console.WriteLine("Account manager is communicating with the donor");
        }

        public void UpdateBalanceBy(decimal amount)
        {
            if (amount > 0) Balance += amount;
            else throw new ArgumentException("amount must be more than 0");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Current Balance: {Balance} EGP");
        }
    }
}
