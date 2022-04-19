using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Models.UserAccount
{
    public class UserAccount
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ComfirmPassword { get; set; }
        public string PasswordHash { get; set; }
        public UserRules Rule { get; set; }
        public int  ComID { get; set; }   = 0;
        public Genders Gender{ get; set; }
        public UeerStatus Status { get; set; }
    }      
}
