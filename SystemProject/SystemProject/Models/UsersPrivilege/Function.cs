using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.UsersPrivilege
{
    public class Function
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string  ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }    
    }
}
