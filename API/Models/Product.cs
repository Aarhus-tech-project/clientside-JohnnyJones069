using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, MaxLength(50)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
    
}