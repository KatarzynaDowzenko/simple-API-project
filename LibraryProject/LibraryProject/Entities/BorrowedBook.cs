using System;

namespace LibraryProject.Entities
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfBorrowingBook { get; set; }
        public DateTime? DateOfReturningBook { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Book book { get; set; } 
    }
}
