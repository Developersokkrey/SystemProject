using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Models.Company
{
    public class Currency
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public string Symbol { get; set; }
        public int ComID { get; set; } = 1;
        public UserStatus Status { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public int Value { get; set; }
    }
}
