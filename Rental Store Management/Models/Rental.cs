using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rental_Store_Management.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Customer ID")]
        public Customer? Customer { get; set; }
        [Required]
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        public Movie? Movie { get; set; }
        [Required]

        [DisplayName("Movie")]
        public int MovieId { get; set;}

        [DisplayName("Date Rented")]
        public DateTime DateRented { get; set; }

        [DisplayName("Date Returned")]
        public DateTime? DateReturned { get; set; }

    }
}
