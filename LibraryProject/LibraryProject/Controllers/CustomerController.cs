using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        //add, delate and check list of users 
        private readonly LibraryDbContext _dbcontext;
        public CustomerController(LibraryDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }
        public ActionResult<IEnumerable<Customers>> GetAll()
        {
            var customer = _dbcontext
                .Books
                .ToList();

            return Ok(customer);
        }
    }
}
