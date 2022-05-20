using System.ComponentModel.DataAnnotations;

namespace SystemProject.Models.Branch
{
    public class Branch
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public int ComID { get; set; }
        
    }
}
