using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rental_Store_Management.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        [DisplayName("Driver's License Number")]
        public string DriverLicenseNumber { get; set; }

    }
}
