
namespace CharitySystem
{
    public class ActivityNeed
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int RequiredQuantity { get; private set; }

        public ActivityNeed(int id, string name, int requiredQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The requirement name cannot be empty.", nameof(name));

            if (requiredQuantity <= 0)
                throw new ArgumentException("The requested quantity must be greater than zero.", nameof(requiredQuantity));

            Id = id;
            Name = name;
            RequiredQuantity = requiredQuantity;
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentException("The requested quantity must be greater than zero.", nameof(newQuantity));

            RequiredQuantity = newQuantity;
        }
    }

}
