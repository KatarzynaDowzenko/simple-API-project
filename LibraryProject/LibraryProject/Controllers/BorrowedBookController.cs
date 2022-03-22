using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Models;
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
        private readonly IMapper _mapper;
        public BorrowedBookController(LibraryDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BorrowedBookDto>> GetAll()
        {
            var borrowedBooks = _dbContext
                .BorrowedBooks
                .ToList();

            var borrowedBooksDto = _mapper.Map<List<BorrowedBookDto>>(borrowedBooks);

            return Ok(borrowedBooksDto);
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
            var borrowedBooksDto = _mapper.Map<List<BorrowedBookDto>>(borrowedBook);

            return Ok(borrowedBooksDto);
        }
    }
}
