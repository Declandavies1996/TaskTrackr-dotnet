using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Pages
{
    public class CompletedTasksModel : PageModel
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        public CompletedTasksModel(IToDoItemsRepository toDoItemsRepository)
        {
            _toDoItemsRepository = toDoItemsRepository;
        }
        [BindProperty]
        public int ToDoItemId { get; set; }
        public IEnumerable<ToDoItem> ToDoItems { get; set; }
        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            ToDoItems = _toDoItemsRepository.GetToDoItemsOpen(User.Identity.Name);

            return Page();
        }
    }
}
