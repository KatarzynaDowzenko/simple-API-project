using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Exceptions;
using LibraryProject.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
    public interface ICustomerService
    {        
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetById(int id);
        int Add(AddCustomerDto dto);
        void Update(int id, UpdateCustomerDto dto);
        void Delete(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(LibraryDbContext dbContext, IMapper mapper, ILogger<CustomerService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
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

            if (customer is null)
            {
                throw new NotFoundException("Customer not found");
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }
        public int Add(AddCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer.Id;
        }

        public void Update(int id, UpdateCustomerDto dto)
        {
            var customer = _dbContext
             .Customers
             .FirstOrDefault(x => x.Id == id);

            if (customer is null)
            {
                throw new NotFoundException("Book not found");
            }

            customer.LastName = dto.LastName;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _dbContext
              .Customers
              .FirstOrDefault(x => x.Id == id);

            if (customer is null)
            {
                throw new NotFoundException("Customer not found");
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}
