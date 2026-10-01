namespace CharitySystem
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;
        private readonly IDonationServes donationServes;

        public ActivityService(IActivityRepository activityRepository, IDonationServes donationServes)
        {
            this.activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            this.donationServes = donationServes ?? throw new ArgumentNullException(nameof(donationServes));
        }

        public Activity CreateActivity(string name, string description, decimal targetAmount)
        {
            int id = activityRepository.GetAll().Count + 1;
            Activity activity = new Activity(id, name, description, targetAmount);
            activityRepository.Add(activity);
            return activity;
        }

        public void UpdateActivity(int activityId, string name, string description)
        {
            Activity activity = GetActivity(activityId);
            activity.UpdateDetails(name, description);
            activityRepository.Update(activity);
        }

        public void SetTarget(int activityId, decimal newTarget)
        {
            Activity activity = GetActivity(activityId);
            activity.SetTarget(newTarget);
            activityRepository.Update(activity);
        }

        public void AddNeed(int activityId, string needName, int requiredQuantity)
        {
            Activity activity = GetActivity(activityId);
            int needId = activity.Needs.Count == 0 ? 1 : activity.Needs.Max(n => n.Id) + 1;
            ActivityNeed need = new ActivityNeed(needId, needName, requiredQuantity);
            activity.AddNeed(need);
            activityRepository.Update(activity);
        }

        public void RemoveNeed(int activityId, int needId)
        {
            Activity activity = GetActivity(activityId);
            activity.RemoveNeed(needId);
            activityRepository.Update(activity);
        }

        public void CloseActivity(int activityId)
        {
            Activity activity = GetActivity(activityId);
            activity.Close();
            activityRepository.Update(activity);
        }

        public Activity GetActivity(int activityId)
        {
            Activity activity = activityRepository.GetById(activityId);
            if (activity == null)
                throw new KeyNotFoundException($"Activity with ID {activityId} was not found.");

            return activity;
        }

        public List<Activity> GetAllActivities()
        {
            return activityRepository.GetAll();
        }

        public decimal GetCollectedAmount(int activityId)
        {
            GetActivity(activityId);

            List<Donations> allDonations = donationServes.ReadDonation();
            decimal total = 0;
            foreach (Donations donation in allDonations)
            {
                if (donation.IdActivity == activityId)
                    total += donation.Amount;
            }

            return total;
        }

        public decimal GetRemainingAmount(int activityId)
        {
            Activity activity = GetActivity(activityId);
            decimal collected = GetCollectedAmount(activityId);
            decimal remaining = activity.TargetAmount - collected;

            return remaining < 0 ? 0 : remaining;
        }

        public decimal GetProgressPercentage(int activityId)
        {
            Activity activity = GetActivity(activityId);
            decimal collected = GetCollectedAmount(activityId);
            decimal percentage = (collected / activity.TargetAmount) * 100;

            return percentage > 100 ? 100 : Math.Round(percentage, 2);
        }

        public ActivityStatus GetStatus(int activityId)
        {
            Activity activity = GetActivity(activityId);
            decimal collected = GetCollectedAmount(activityId);

            if (activity.Status != ActivityStatus.Closed)
            {
                if (collected >= activity.TargetAmount)
                    activity.MarkAsCompleted();
                else
                    activity.ReopenIfCompleted();

                activityRepository.Update(activity);
            }

            return activity.Status;
        }
    }
}
