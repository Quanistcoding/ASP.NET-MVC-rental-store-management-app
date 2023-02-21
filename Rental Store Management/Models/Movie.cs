using System.ComponentModel.DataAnnotations;

namespace Rental_Store_Management.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        public Genre? Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

        [Required]
        [Range(0,Int32.MaxValue)]
        public int NumberInStock { get; set; }

    }
}
