using System.ComponentModel.DataAnnotations;

namespace SystemProject.Models.Branch
{
    public class BranchInfo
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int BranID { get; set; }
        public int Tel1 { get; set; }
        public int Tel2 { get; set; }
        public int Tel3 { get; set; }
        public int Tel4 { get; set; }
        public int Tel5 { get; set; }
        public string Des1 { get; set; }
        public string Des2 { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }

    }
}
