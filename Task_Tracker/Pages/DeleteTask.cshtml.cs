using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Tracker.Interfaces;
using Task_Tracker.Models;

namespace Task_Tracker.Pages
{
    public class DeleteTaskModel : PageModel
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        public DeleteTaskModel(IToDoItemsRepository toDoItemsRepository)
        {
            _toDoItemsRepository = toDoItemsRepository;
        }
        [BindProperty]  
        public ToDoItem ToDoItem { get; set; }
        public IActionResult OnGet(int toDoItemId)
        {
            if(!User.Identity.IsAuthenticated)
            {
                RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            ToDoItem = _toDoItemsRepository.GetToDoItemById(toDoItemId);

            return Page();
        }
        public IActionResult OnPost(ToDoItem toDoItem)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _toDoItemsRepository.DeleteToDoItem(toDoItem.ToDoItemId);

            return RedirectToPage("TasksList");
        }   
    }
}
