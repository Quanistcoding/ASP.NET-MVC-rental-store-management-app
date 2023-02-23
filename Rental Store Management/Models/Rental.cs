using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rental_Store_Management.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        public Customer? Customr { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Driver's License No.")]
        public string CustomerDriverLicenseNumber { get; set; }

        public Movie? Movie { get; set; }

        [Required]
        [DisplayName("Movie")]
        public int MovieId { get; set; }

        [Required]
        [DisplayName("Date Rented")]
        public DateTime DateRented { get; set; }

        [DisplayName("Date Returned")]
        public DateTime? DateReturned { get; set; }

    }

}
