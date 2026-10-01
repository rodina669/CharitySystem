namespace CharitySystem
{
    public class ActivityManager : SystemUser
    {
        private readonly IActivityService activityService;

        public ActivityManager(string userName, string password, int age, string phoneNumber, IActivityService activityService)
            : base(userName, password, age, phoneNumber)
        {
            this.activityService = activityService ?? throw new ArgumentNullException(nameof(activityService));
        }

        public Activity CreateActivity(string name, string description, decimal targetAmount)
            => activityService.CreateActivity(name, description, targetAmount);

        public void UpdateActivity(int activityId, string name, string description)
            => activityService.UpdateActivity(activityId, name, description);

        public void CloseActivity(int activityId)
            => activityService.CloseActivity(activityId);

        public void SetTarget(int activityId, decimal newTarget)
            => activityService.SetTarget(activityId, newTarget);

        public void AddNeed(int activityId, string needName, int requiredQuantity)
            => activityService.AddNeed(activityId, needName, requiredQuantity);

        public void RemoveNeed(int activityId, int needId)
            => activityService.RemoveNeed(activityId, needId);

        public ActivityStatus GetActivityStatus(int activityId)
            => activityService.GetStatus(activityId);

        public decimal GetTargetAmount(int activityId)
            => activityService.GetActivity(activityId).TargetAmount;

        public decimal GetCollectedAmount(int activityId)
            => activityService.GetCollectedAmount(activityId);

        public decimal GetRemainingAmount(int activityId)
            => activityService.GetRemainingAmount(activityId);

        public decimal GetProgressPercentage(int activityId)
            => activityService.GetProgressPercentage(activityId);

        public List<Activity> GetAllActivities()
            => activityService.GetAllActivities();
    }
}
