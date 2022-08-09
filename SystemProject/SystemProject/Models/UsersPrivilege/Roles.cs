using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.UsersPrivilege
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; } = true;
        public string ComID { get; set; }
    }
}
