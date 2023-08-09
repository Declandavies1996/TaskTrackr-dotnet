using Microsoft.EntityFrameworkCore;
using Task_Tracker.Data;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Repositorys
{
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoItemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            _context.SaveChanges();
        }

        public void DeleteToDoItem(int toDoItemId)
        {
            _context.ToDoItems.Remove(GetToDoItemById(toDoItemId));
            _context.SaveChanges();
        }

        public IEnumerable<ToDoItem> GetAllToDoItems()
        {
            return _context.ToDoItems.Include(c => c.Status).ToList();
        }

        public ToDoItem GetToDoItemById(int toDoItemId)
        {
            return _context.ToDoItems.Include(c => c.Status).FirstOrDefault(x => x.ToDoItemId == toDoItemId);
        }

        public IEnumerable<ToDoItem> GetToDoItemsByUser(string username)
        {
            return _context.ToDoItems.Include(c=>c.Status).Where(x => x.Username == username).ToList();
        }

        public IEnumerable<ToDoItem> GetToDoItemsCompleted(string username)
        {
            return _context.ToDoItems.Include(c => c.Status).Where(x => x.Username == username && x.StatusId == 1).ToList();
        }

        public IEnumerable<ToDoItem> GetToDoItemsOpen(string username)
        {
            return _context.ToDoItems.Include(c => c.Status).Where(x => x.Username == username && x.StatusId != 1).ToList();
        }

        public void UpdateToDoItem(ToDoItem toDoItem)
        {
            _context.Entry(toDoItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
