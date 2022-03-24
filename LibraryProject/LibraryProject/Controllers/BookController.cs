using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryProject.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAll()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> Get([FromRoute] int id)
        {
            var book = _bookService.GetById(id);

            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] AddBookDto dto)
        {
            var id = _bookService.Add(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpPut("{id})")]
        public ActionResult Update([FromBody] UpdateBookDto dto, [FromRoute] int id)
        {
            _bookService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
