using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class UpdateBorrowedBookDto
    {
        [Required]
        public DateTime DateOfReturningBook { get; set; }
    }
}
