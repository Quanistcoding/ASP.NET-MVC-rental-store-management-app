﻿using System.ComponentModel.DataAnnotations;

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
        public string Phone  { get; set; }

        [Required]
        public string DriverLicenseNumber { get; set; }

        public MembershipType? MembershipType { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }
    }
}