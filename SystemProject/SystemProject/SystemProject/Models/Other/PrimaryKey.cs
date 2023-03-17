using System.ComponentModel.DataAnnotations;
using static SystemProject.Model.EnumService.EnumServices;

namespace SystemProject.Models.Other
{
    public class PrimaryKey
    {
        [Key]
        public int ID { get; set; }
        public TableName TableName { get; set; }
        public string KeyNumber { get; set; }
    }
}
