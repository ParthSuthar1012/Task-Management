using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management.Models
{
    public class User
    {
        public int UserId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(8)]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Email { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        [ValidateNever]
        public Roles Roles { get; set; }
    }
}
