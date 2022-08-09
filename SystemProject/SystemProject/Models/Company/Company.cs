using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.Company
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string SC { get; set; }          
        public string LC { get; set; }
        [NotMapped]
        public string SCName { get; set; }
        [NotMapped]
        public string LCName { get; set; }
    }
}
