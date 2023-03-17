using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.Branch
{
    public class BranchInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string Code {get;set;}
        public string Name { get; set; }
        public string Logo { get; set; }
        public string BranID { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Tel4 { get; set; }
        public string Tel5 { get; set; }
        public string Des1 { get; set; }
        public string Des2 { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }

    }
}
