using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Models.Company
{
    public class Currency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string Code {get;set;}
        public string Name { get; set; }
        public string Des { get; set; }
        public string Symbol { get; set; }
        public string ComID { get; set; } 
        public UserStatus Status { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public string Value { get; set; }
    }
}
