using System;
using System.Collections.Generic;

namespace LibraryProject.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual List<Customers> BorrowedBooks { get; set; }
    }
}
