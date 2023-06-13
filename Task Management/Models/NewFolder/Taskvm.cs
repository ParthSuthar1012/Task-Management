using System.ComponentModel.DataAnnotations;
using Task_Management.SD;

namespace Task_Management.Models.NewFolder
{
    public class Taskvm
    {
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public int AssignedTo { get; set; }
        [Required]
        public int CreatedBy { get; set; }
   
    }
}
