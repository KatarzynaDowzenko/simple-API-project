using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class AddCustomerDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
