using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Pages
{
    public class TasksListModel : PageModel
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        public TasksListModel(IToDoItemsRepository toDoItemsRepository)
        {
            _toDoItemsRepository = toDoItemsRepository;
        }
        [BindProperty]
        public int ToDoItemId { get; set; } 
        public IEnumerable<ToDoItem> ToDoItems { get; set; }
        public IActionResult OnGet()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            ToDoItems = _toDoItemsRepository.GetToDoItemsOpen(User.Identity.Name);
            
            return Page();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var toDoItem = _toDoItemsRepository.GetToDoItemById(ToDoItemId);
            toDoItem.StatusId = 1;

            _toDoItemsRepository.UpdateToDoItem(toDoItem);

            return RedirectToPage("TasksList");
        }
    }
}
