using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult AddBorrowedBook([FromBody] AddBorrowedBookDto dto)
        {            
            var id = _borrowedBookService.Add(dto);
            return Created($"/api/borrowedbooks/{id}", null);
        }

        [HttpPut("{id})")]
        public ActionResult UpdateBorrowedBook([FromBody] UpdateBorrowedBookDto dto, [FromRoute] int id)
        {
            _borrowedBookService.Update(id, dto);
            return Ok();
        }
    }
}
