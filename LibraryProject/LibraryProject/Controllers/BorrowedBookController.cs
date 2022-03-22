using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/borrowedbooks")]
    public class BorrowedBookController : ControllerBase
    {
        //get or give back borrowed books and check list of all aviliable books
        private readonly LibraryDbContext _dbContext;
        public BorrowedBookController(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BorrowedBook>> GetAll()
        {
            var borrowedBooks = _dbContext
                .Books
                .ToList();

            return Ok(borrowedBooks);
        }

        [HttpGet("{id}")]
        public ActionResult<BorrowedBook> Get([FromRoute] int id)
        {
            var borrowedBook = _dbContext
               .BorrowedBooks
               .FirstOrDefault(x => x.Id == id);

            if (borrowedBook is null)
            {
                return NotFound();
            }

            return Ok(borrowedBook);
        }
    }
}
