namespace CharitySystem
{
    public interface IActivityRepository
    {
        void Add(Activity activity);
        void Update(Activity activity);
        Activity GetById(int id);
        List<Activity> GetAll();
    }
}
