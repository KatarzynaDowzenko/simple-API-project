using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class AddBookDto
    {
        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }

        [Required]
        [MaxLength(100)]
        public string AuthorLastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeOfBook { get; set; }
        
        [Required]        
        public DateTime ReleaseDate { get; set; }        
    }
}
