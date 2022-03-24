using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryProject.Controllers
{
    [Route("api/borrowedbooks")]
    [ApiController]
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

            return Ok(borrowedBook);
        }

        [HttpPost]
        public ActionResult AddBorrowedBook([FromBody] AddBorrowingBookDto dto)
        {            
            var id = _borrowedBookService.Add(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpPut("{id})")]
        public ActionResult Update([FromBody] UpdateBorrowedBookDto dto, [FromRoute] int id)
        {
            _borrowedBookService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _borrowedBookService.Delete(id);

            return NoContent();
        }
    }
}
