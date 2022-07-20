using System.ComponentModel.DataAnnotations;

namespace SystemProject.Models.Branch
{
    public class Branch
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]                   
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int ComID { get; set; }
        
    }
}
