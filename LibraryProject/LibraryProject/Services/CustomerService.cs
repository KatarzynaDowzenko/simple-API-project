using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
    public interface ICustomerService
    {
        int Add(AddCustomerDto dto);
        bool Delete(int id);
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetById(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _dbContext
                .Customers
                .ToList();

            var customersDto = _mapper.Map<List<CustomerDto>>(customers);

            return customersDto;
        }

        public CustomerDto GetById(int id)
        {
            var customer = _dbContext
               .Customers
               .FirstOrDefault(x => x.Id == id);

            if (customer is null) return null;

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }

        public bool Delete(int id)
        {
            var customer = _dbContext
              .Customers
              .FirstOrDefault(x => x.Id == id);

            if (customer is null) return false;

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();

            return true;
        }

        public int Add(AddCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer.Id;
        }
    }
}
