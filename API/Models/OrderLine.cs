using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("OrderLine")]
    public class OrderLine
    {
        [Key]
        [Column(Order = 0)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public Decimal UnitPrice { get; set; }
    }
}