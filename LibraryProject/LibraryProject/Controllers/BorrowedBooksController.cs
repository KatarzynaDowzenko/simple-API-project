using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/borrowedbooks")]
    public class BorrowedBooksController : ControllerBase
    {
        //get or give back borrowed books and check list of all aviliable books
        private readonly LibraryDbContext _dbcontext;
        public BorrowedBooksController(LibraryDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }
        public ActionResult<IEnumerable<Customers>> GetAll()
        {
            var borrowedBooks = _dbcontext
                .Books
                .ToList();

            return Ok(borrowedBooks);
        }
    }
}
