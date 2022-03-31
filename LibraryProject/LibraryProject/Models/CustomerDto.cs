using System.Collections.Generic;

namespace LibraryProject.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<BorrowedBookDto> BorrowedBooksList { get; set; }
    }
}