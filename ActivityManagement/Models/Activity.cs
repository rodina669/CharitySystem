namespace CharitySystem
{
    public class Activity
    {
        private List<ActivityNeed> needs = new();

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal TargetAmount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }
        public ActivityStatus Status { get; private set; }
        public List<ActivityNeed> Needs => needs;

        public Activity(int id, string name, string description, decimal targetAmount)
        {
            ValidateName(name);
            ValidateTargetAmount(targetAmount);

            Id = id;
            Name = name;
            Description = description ?? string.Empty;
            TargetAmount = targetAmount;
            CreatedAt = DateTime.UtcNow;
            Status = ActivityStatus.Open;
        }

        public void UpdateDetails(string name, string description)
        {
            EnsureNotClosed();
            ValidateName(name);

            Name = name;
            Description = description ?? string.Empty;
        }

        public void SetTarget(decimal newTarget)
        {
            EnsureNotClosed();
            ValidateTargetAmount(newTarget);

            TargetAmount = newTarget;
        }

        public void AddNeed(ActivityNeed need)
        {
            EnsureNotClosed();

            if (need == null)
                throw new ArgumentNullException(nameof(need));

            bool alreadyExists = false;
            foreach (ActivityNeed existingNeed in needs)
            {
                if (existingNeed.Name.ToLower() == need.Name.ToLower())
                {
                    alreadyExists = true;
                    break;
                }
            }

            if (alreadyExists)
                throw new InvalidOperationException($"The requirement '{need.Name}' already exists for this activity.");

            needs.Add(need);
        }

        public void RemoveNeed(int needId)
        {
            EnsureNotClosed();

            ActivityNeed needToRemove = null;
            foreach (ActivityNeed existingNeed in needs)
            {
                if (existingNeed.Id == needId)
                {
                    needToRemove = existingNeed;
                    break;
                }
            }

            if (needToRemove == null)
                throw new KeyNotFoundException($"There is no need with the ID '{needId}'.");

            needs.Remove(needToRemove);
        }

        public void MarkAsCompleted()
        {
            EnsureNotClosed();
            Status = ActivityStatus.Completed;
        }

        public void ReopenIfCompleted()
        {
            if (Status == ActivityStatus.Completed)
                Status = ActivityStatus.Open;
        }

        public void Close()
        {
            EnsureNotClosed();
            Status = ActivityStatus.Closed;
            ClosedAt = DateTime.UtcNow;
        }

        private void EnsureNotClosed()
        {
            if (Status == ActivityStatus.Closed)
                throw new InvalidOperationException($"Cannot modify activity '{Name}' because it is already closed.");
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The activity name cannot be empty.", nameof(name));
        }

        private static void ValidateTargetAmount(decimal targetAmount)
        {
            if (targetAmount <= 0)
                throw new ArgumentException("The target amount must be greater than zero.", nameof(targetAmount));
        }
    }
}
