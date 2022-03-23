using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
    public interface IBorrowedBookService
    {
        int Add(AddBorrowingBookDto dto);
        bool Delete(int id);
        IEnumerable<BorrowedBookDto> GetAll();
        BorrowedBookDto GetById(int id);
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

            if (borrowedBook is null) return null;

            var borrowedBookDto = _mapper.Map<BorrowedBookDto>(borrowedBook);

            return borrowedBookDto;
        }

        public bool Delete(int id)
        {
            var borrowedBook = _dbContext
              .BorrowedBooks
              .FirstOrDefault(x => x.Id == id);

            if (borrowedBook is null) return false;

            _dbContext.BorrowedBooks.Remove(borrowedBook);
            _dbContext.SaveChanges();

            return true;
        }

        public int Add(AddBorrowingBookDto dto)
        {
            var borrowedBook = _mapper.Map<BorrowedBook>(dto);
            _dbContext.BorrowedBooks.Add(borrowedBook);
            _dbContext.SaveChanges();

            return borrowedBook.Id;
        }
    }
}
