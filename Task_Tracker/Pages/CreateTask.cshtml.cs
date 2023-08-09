using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Pages
{
    public class CreateTaskModel : PageModel
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        private readonly IStatusRepository _statusRepository;
        public CreateTaskModel(IToDoItemsRepository toDoItemsRepository, IStatusRepository statusRepository)
        {
            _toDoItemsRepository = toDoItemsRepository;
            _statusRepository = statusRepository;   
        }
        [BindProperty]
        public ToDoItem ToDoItem { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IActionResult OnGet()
        {
            if(!User.Identity.IsAuthenticated)
            {
                RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            ToDoItem = new ToDoItem()
            {
                Username = User.Identity.Name,
                DueDate = DateTime.Now
            };

            Statuses = _statusRepository.GetStatuses();

            return Page();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _toDoItemsRepository.AddToDoItem(ToDoItem);

            return RedirectToPage("TasksList");
        }   
    }
}
