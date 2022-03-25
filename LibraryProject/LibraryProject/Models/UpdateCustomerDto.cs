using LibraryProject.Entities;
using System.Collections.Generic;

namespace LibraryProject.Models
{
    public class UpdateCustomerDto
    {
        public string LastName { get; set; }
        public List<BorrowedBook> BorrowedBooksList { get; set; }
    }
}
