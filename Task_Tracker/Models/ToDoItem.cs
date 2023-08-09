using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Tracker.Models
{
    public class ToDoItem
    {
        [Required]
        public int ToDoItemId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Task Name is required.")]
        public string ToDoItemName { get; set; }

        [Required(ErrorMessage = "Task Description is required.")]
        public string ToDoItemDescription { get; set; }

        [Required(ErrorMessage = "Due Date is required.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [ForeignKey("Status")]
        public int StatusId { get; set; }


        public Status? Status { get; set; }
    }
}
