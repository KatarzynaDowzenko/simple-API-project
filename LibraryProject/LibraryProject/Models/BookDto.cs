using System;

namespace LibraryProject.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string Title { get; set; }
        public string TypeOfBook { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
