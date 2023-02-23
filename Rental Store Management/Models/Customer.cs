using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rental_Store_Management.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(12)]
        [Phone]
        public string Phone  { get; set; }

        [Required]
        [DisplayName("Driver's License Number")]
        public string DriverLicenseNumber { get; set; }
        [DisplayName(" Membership Type")]

        public MembershipType? MembershipType { get; set; }

        [Required]
        [DisplayName("Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}
