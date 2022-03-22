using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        //add, delate and check list of users 
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerController(LibraryDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
        }
        public ActionResult<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = _dbContext
                .Customers
                .ToList();

            var customerDto = _mapper.Map<List<CustomerDto>>(customers);

            return Ok(customerDto);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get([FromRoute] int id)
        {
            var customer = _dbContext
               .Customers
               .FirstOrDefault(x => x.Id == id);

            if (customer is null)
            {
                return NotFound();
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return Ok(customerDto);
        }
    }
}
