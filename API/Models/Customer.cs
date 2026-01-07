using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Customer") ]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }
    }
}