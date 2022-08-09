using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.UsersPrivilege
{
    public class RolesPrivilege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string RoleID { get; set; }
        public string FuncID { get; set; }
        public bool Enable { get; set; } = true;
    }
}
