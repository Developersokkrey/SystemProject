using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SystemProject.Models.UserAccount
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; } 
        public string Code {get;set;}
        public string Name { get; set; }
        public string ComID { get; set; }
        public bool Enable {get; set;}
    }      
}