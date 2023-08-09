using Task_Tracker.Models;

namespace Task_Tracker.Interfaces
{
    public interface IToDoItemsRepository
    { 
        void AddToDoItem(ToDoItem toDoItem);
        void UpdateToDoItem(ToDoItem toDoItem);
        void DeleteToDoItem(int toDoItemId);
        ToDoItem GetToDoItemById(int toDoItemId);
        IEnumerable<ToDoItem> GetToDoItemsByUser(string username);
        IEnumerable<ToDoItem> GetToDoItemsOpen(string username);
        IEnumerable<ToDoItem> GetToDoItemsCompleted(string username);
        IEnumerable<ToDoItem> GetAllToDoItems();
    }
}
