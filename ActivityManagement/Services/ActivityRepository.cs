namespace CharitySystem
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly Dictionary<int, Activity> store = new();

        public void Add(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            store[activity.Id] = activity;
        }

        public void Update(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            if (!store.ContainsKey(activity.Id))
                throw new KeyNotFoundException($"Activity with ID {activity.Id} was not found.");

            store[activity.Id] = activity;
        }

        public Activity GetById(int id)
        {
            if (store.ContainsKey(id))
                return store[id];

            return null;
        }

        public List<Activity> GetAll()
        {
            return new List<Activity>(store.Values);
        }
    }
}
