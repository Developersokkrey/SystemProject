using System.ComponentModel.DataAnnotations;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Model.UserAccount
{
    public class UserAccount
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserRoles Role { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public Genders Gender{ get; set; }
        [Required]
        public UeerStatus Status { get; set; }
    }      
}
