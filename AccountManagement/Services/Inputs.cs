namespace CharitySystem
{
    public static class Inputs
    {
        public static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("you don't enter anything");
                else
                    return input;
            }
        }

        public static int ReadInt(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    int v = int.Parse(Console.ReadLine());
                    return v;
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter a valid number");
                }
            }
        }

        public static decimal ReadDecimal(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    decimal v = decimal.Parse(Console.ReadLine());

                    if (v >= 0) return v;

                    Console.WriteLine("you can't enter a negative number");
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter a valid amount");
                }
            }
        }
    }
}
