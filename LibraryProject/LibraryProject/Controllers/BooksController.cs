using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        //check list of books and add/delate book, changed bookstatus
        private readonly LibraryDbContext _dbcontext;
        public BooksController(LibraryDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _dbcontext
                .Books
                .ToList();

            return Ok(books);
        }
    }
}
