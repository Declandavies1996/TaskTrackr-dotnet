using Task_Tracker.Models;

namespace Task_Tracker.Interfaces
{
    public interface IStatusRepository
    {
        Status GetStatus(int id);
        IEnumerable<Status> GetStatuses();
    }
}
