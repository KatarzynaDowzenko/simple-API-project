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
    }
}
