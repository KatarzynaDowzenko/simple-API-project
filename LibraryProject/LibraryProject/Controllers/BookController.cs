using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        //check list of books and add/delate book, changed bookstatus
        private readonly LibraryDbContext _dbContext;
        public BookController(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _dbContext
                .Books
                .ToList();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get([FromRoute] int id)
        {
            var book = _dbContext
               .Books
               .FirstOrDefault(x => x.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
