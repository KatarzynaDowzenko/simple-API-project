using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryProject.Controllers
{
    [Route("api/borrowed-books")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowedBookService;
        public BorrowedBookController(IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
        }        

        [HttpPost]
        public ActionResult BorrowBook([FromBody] AddBorrowedBookDto dto)
        {            
            if(_borrowedBookService.IsBorrowed(dto.BookId))
            {
                throw new Exception("This book is already borrowed.");
            }

            var id = _borrowedBookService.Add(dto);
            return Created($"/api/borrowed-books/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult ReturndBook([FromBody] ReturnBorrowedBookDto dto, [FromRoute] int id)
        {
            _borrowedBookService.Update(id, dto);
            return Ok();
        }
    }
}