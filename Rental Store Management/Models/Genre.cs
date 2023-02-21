using System.ComponentModel.DataAnnotations;

namespace Rental_Store_Management.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }    

    }
}