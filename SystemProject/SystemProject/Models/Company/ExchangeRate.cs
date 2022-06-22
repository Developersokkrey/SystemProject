using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.Company
{
    public class ExchangeRate
    {
        [Key]
        public int ID { get; set; }
        public int CurrID { get; set; }
        [Column(TypeName = "decimal(36,18)")]
        public decimal Rate1 { get; set; }
        [Column(TypeName = "decimal(36,18)")]
        public decimal Rate2 { get; set; }
        [NotMapped]
        public string CurrName { get; set; }
    }
}
