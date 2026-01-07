using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public int StatusID { get; set; }

        public DateTime OrderDate { get; set; }
    }
}