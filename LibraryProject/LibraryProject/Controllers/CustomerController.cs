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
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] AddCustomerDto dto)
        {
            var id = _customerService.Add(dto);
            return Created($"/api/customers/{id}", null);
        }

        [HttpPut("{id})")]
        public ActionResult UpdateCustomer([FromBody] UpdateCustomerDto dto, [FromRoute] int id)
        {
            _customerService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer([FromRoute] int id)
        {
            _customerService.Delete(id);
            return NoContent();
        }
    }
}