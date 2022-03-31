using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class ReturnBorrowedBookDto
    {
        [Required]
        public DateTime DateOfReturningBook { get; set; }
    }
}