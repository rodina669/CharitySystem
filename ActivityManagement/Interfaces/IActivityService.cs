
namespace CharitySystem
{
 
    public interface IActivityService
    {
        Activity CreateActivity(string name,string description,decimal targetAmount);
        void UpdateActivity(int activityId,string name,string description);
        void SetTarget(int activityId,decimal newTarget);
        void CloseActivity(int activityId);
        void AddNeed(int activityId,string needName,int requiredQuantity);
        void RemoveNeed(int activityId,int needId);
        decimal GetCollectedAmount(int activityId);
        decimal GetRemainingAmount(int activityId);
        decimal GetProgressPercentage(int activityId);
        ActivityStatus GetStatus(int activityId);
        Activity GetActivity(int activityId);
        List<Activity> GetAllActivities();
    }
    
}
