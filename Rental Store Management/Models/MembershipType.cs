
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rental_Store_Management.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        [DisplayName("Discount Rate")]
        public int DiscountRate{ get; set; }

    }
}