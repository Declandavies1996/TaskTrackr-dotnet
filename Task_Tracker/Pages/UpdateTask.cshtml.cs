using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Pages
{
    public class UpdateTaskModel : PageModel
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        private readonly IStatusRepository _statusRepository;
        public UpdateTaskModel(IToDoItemsRepository toDoItemsRepository, IStatusRepository statusRepository)
        {
            _toDoItemsRepository = toDoItemsRepository;
            _statusRepository = statusRepository;
        }
        [BindProperty]
        public ToDoItem ToDoItem { get; set; }
        public IEnumerable<Status> Status { get; set; }
        public IActionResult OnGet(int toDoItemId)
        {
            if(!User.Identity.IsAuthenticated)
            {
                RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            ToDoItem = _toDoItemsRepository.GetToDoItemById(toDoItemId);
            Status = _statusRepository.GetStatuses();

            return Page();
        }
        public IActionResult OnPost(ToDoItem toDoItem)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _toDoItemsRepository.UpdateToDoItem(toDoItem);

            return RedirectToPage("TasksList");
        }   
    }
}
