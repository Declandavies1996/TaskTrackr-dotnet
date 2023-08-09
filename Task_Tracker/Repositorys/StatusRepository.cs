using Task_Tracker.Data;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Repositorys
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Status GetStatus(int id)
        {
            return _context.Statuses.Find(id);
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _context.Statuses;
        }
    }
}
