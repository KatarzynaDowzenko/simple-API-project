﻿using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class AddBorrowedBookDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}