using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Task_Management.Models
{
    public class Assignedto
    {
        [Key]
        public int AssignedId { get; set; }
    
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        [ValidateNever]
        public Task task { get; set; }
     
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User AssignUser { get; set; }
    }
}
