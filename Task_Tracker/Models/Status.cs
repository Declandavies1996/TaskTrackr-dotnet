using System.ComponentModel.DataAnnotations;

namespace Task_Tracker.Models
{
    public class Status
    {
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
