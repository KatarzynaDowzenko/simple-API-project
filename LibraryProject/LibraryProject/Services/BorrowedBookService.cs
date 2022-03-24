using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Exceptions;
using LibraryProject.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
    public interface IBorrowedBookService
    {        
        IEnumerable<BorrowedBookDto> GetAll();
        BorrowedBookDto GetById(int id);
        int Add(AddBorrowingBookDto dto);
        void Update(int id, UpdateBorrowedBookDto dto);
        void Delete(int id);
    }

    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BorrowedBookService> _logger;
        public BorrowedBookService(LibraryDbContext dbContext, IMapper mapper, ILogger<BorrowedBookService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<BorrowedBookDto> GetAll()
        {
            var borrowedBooks = _dbContext
                .BorrowedBooks
                .ToList();

            var borrowedBooksDto = _mapper.Map<List<BorrowedBookDto>>(borrowedBooks);

            return borrowedBooksDto;
        }

        public BorrowedBookDto GetById(int id)
        {
            var borrowedBook = _dbContext
               .BorrowedBooks
               .FirstOrDefault(x => x.Id == id);

            if (borrowedBook is null)
                if (borrowedBook is null)
                {
                    throw new NotFoundException("BorrowedBook not found");
                }

            var borrowedBookDto = _mapper.Map<BorrowedBookDto>(borrowedBook);

            return borrowedBookDto;
        }
        public int Add(AddBorrowingBookDto dto)
        {
            var borrowedBook = _mapper.Map<BorrowedBook>(dto);
            _dbContext.BorrowedBooks.Add(borrowedBook);
            _dbContext.SaveChanges();

            return borrowedBook.Id;
        }
        public void Update(int id, UpdateBorrowedBookDto dto)
        {
            var borrowedBook = _dbContext
             .BorrowedBooks
             .FirstOrDefault(x => x.Id == id);

            if (borrowedBook is null)
            {
                throw new NotFoundException("Book not found");
            }

            borrowedBook.DateOfReturningBook = dto.DateOfReturningBook;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var borrowedBook = _dbContext
              .BorrowedBooks
              .FirstOrDefault(x => x.Id == id);

            if (borrowedBook is null)
            {
                throw new NotFoundException("BorrowedBook not found");
            }

            _dbContext.BorrowedBooks.Remove(borrowedBook);
            _dbContext.SaveChanges();
        }
    }
}
