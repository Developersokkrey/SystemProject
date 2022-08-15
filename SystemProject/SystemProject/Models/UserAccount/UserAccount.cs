using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SystemProject.Models.UsersPrivilege;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Models.UserAccount
{
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string Username { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string PasswordHash { get; set; }
        public string RoleID { get; set; }
        public string ComID { get; set; }
        public string BranID { get; set; }
        public Genders Gender{ get; set; }
        public UserStatus Status { get; set; }
        [NotMapped]
        public List<Roles> Roles { get; set; }
    }      
}
