using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.Company
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public int SC { get; set; }          
        public int LC { get; set; }
        [NotMapped]
        public string SCName { get; set; }
        [NotMapped]
        public string LCName { get; set; }
    }
}
