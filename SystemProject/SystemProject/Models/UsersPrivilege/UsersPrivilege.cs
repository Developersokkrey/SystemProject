using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Models.UsersPrivilege
{
    public class UsersPrivilege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string UserID { get; set; }
        public string RolePriviID { get; set; }
        public string FuncID { get; set; }          
        public bool Enable { get; set; } = false;
    }
}
