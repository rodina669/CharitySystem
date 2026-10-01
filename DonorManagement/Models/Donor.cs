namespace CharitySystem
{
    public class Donor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinData { get; set; } = DateTime.Now;

        public void Sarch()
        {
            Console.WriteLine($" id  : {Id}");
            Console.WriteLine($" name  : {Name}");
            Console.WriteLine($" email  : {Email}");
            Console.WriteLine($" phonenumper  : {PhoneNumber}");
            Console.WriteLine($" datetime  : {JoinData}");
        }
    }
}
