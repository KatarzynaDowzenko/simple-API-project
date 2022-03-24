using LibraryProject.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class UpdateBookDto
    {
        [Required]
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BookStatusId { get; set; }
    }
}
