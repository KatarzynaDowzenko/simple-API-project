using System;

namespace LibraryProject.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string Title { get; set; }
        public string TypeOfBook { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? BookStatusId { get; set; }
        public virtual BookStatus Status { get; set; }
    }
}
