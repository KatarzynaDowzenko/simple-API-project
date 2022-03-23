using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryProject.Controllers
{
    [Route("api/borrowedbooks")]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowedBookService;
        public BorrowedBookController(IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BorrowedBookDto>> GetAll()
        {
            var borrowedBooks = _borrowedBookService.GetAll();

            return Ok(borrowedBooks);
        }

        [HttpGet("{id}")]
        public ActionResult<BorrowedBookDto> Get([FromRoute] int id)
        {
            var borrowedBook = _borrowedBookService.GetById(id);

            if (borrowedBook is null)
            {
                return NotFound();
            }

            return Ok(borrowedBook);
        }

        [HttpPost]
        public ActionResult AddBorrowedBook([FromBody] AddBorrowingBookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _borrowedBookService.Add(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _borrowedBookService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
