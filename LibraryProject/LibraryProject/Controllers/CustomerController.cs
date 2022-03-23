using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryProject.Controllers
{
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = _customerService.GetAll();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get([FromRoute] int id)
        {
            var customer = _customerService.GetById(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] AddCustomerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _customerService.Add(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _customerService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
