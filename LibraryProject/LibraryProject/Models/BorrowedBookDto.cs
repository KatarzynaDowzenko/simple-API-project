using System;

namespace LibraryProject.Models
{
    public class BorrowedBookDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfBorrowingBook { get; set; }
        public DateTime? DateOfReturningBook { get; set; }
    }
}
