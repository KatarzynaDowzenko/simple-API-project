using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        //check list of books and add/delate book, changed bookstatus
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public BookController(LibraryDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] AddBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return Created($"/api/restaurant/{book.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAll()
        {
            var books = _dbContext
                .Books
                .ToList();

            var booksDto = _mapper.Map<List<BookDto>>(books);

            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> Get([FromRoute] int id)
        {
            var book = _dbContext
               .Books
               .FirstOrDefault(x => x.Id == id);

            if (book is null)
            {
                return NotFound();
            }
            var booksDto = _mapper.Map<BookDto>(book);

            return Ok(booksDto);
        }
    }
}
