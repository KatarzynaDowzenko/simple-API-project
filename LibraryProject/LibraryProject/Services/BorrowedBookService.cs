using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Exceptions;
using LibraryProject.Models;
using System.Linq;

namespace LibraryProject.Services
{
    public interface IBorrowedBookService
    {
        int Add(AddBorrowedBookDto dto);
        bool IsBorrowed(int id);
        void Update(int id, ReturnBorrowedBookDto dto);
    }

    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public BorrowedBookService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool IsBorrowed(int id)
        {
            var borrowed = _dbContext.BorrowedBooks.Any(x => !x.DateOfReturningBook.HasValue && x.BookId == id);
            return borrowed;
        }

        public int Add(AddBorrowedBookDto dto)
        {
            var borrowedBook = _mapper.Map<BorrowedBook>(dto);
            _dbContext.BorrowedBooks.Add(borrowedBook);
            _dbContext.SaveChanges();

            return borrowedBook.Id;
        }

        public void Update(int id, ReturnBorrowedBookDto dto)
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