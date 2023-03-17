using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemProject.Models.Company
{
    public class ExchangeRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string CurrID { get; set; }
        [Column(TypeName = "decimal(36,18)")]
        public decimal Rate1 { get; set; }
        [Column(TypeName = "decimal(36,18)")]
        public decimal Rate2 { get; set; }
        [NotMapped]
        public string CurrName { get; set; }
    }
}
