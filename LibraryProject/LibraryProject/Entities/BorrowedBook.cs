using System;
namespace LibraryProject.Entities
{
    public class Customers
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfBorrowingBook { get; set; }
        public DateTime? DateOfReturningBook { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; } 
    }
}