using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models.NewFolder
{
    public class registerVm
    {
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MinLength(8)]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Email { get; set; }

        public int RoleID { get; set; }
    }
}
