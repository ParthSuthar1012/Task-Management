using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string RoleName { get; set; }
    }
}
