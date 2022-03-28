using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Exceptions;
using LibraryProject.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace LibraryProject.Services
{
    public interface IBorrowedBookService
    {
        int Add(AddBorrowedBookDto dto);
        void Update(int id, UpdateBorrowedBookDto dto);
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
        public int Add(AddBorrowedBookDto dto)
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
    }
}
