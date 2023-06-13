using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models.NewFolder
{
    public class loginvm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
