using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}