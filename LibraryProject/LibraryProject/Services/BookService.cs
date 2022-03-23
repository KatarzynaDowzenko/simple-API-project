using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
    public interface IBookService
    {
        int Add(AddBookDto dto);
        bool Delete(int id);
        IEnumerable<BookDto> GetAll();
        BookDto GetById(int id);
    }

    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public BookService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetAll()
        {
            var books = _dbContext
                .Books
                .ToList();

            var booksDto = _mapper.Map<List<BookDto>>(books);

            return booksDto;
        }

        public BookDto GetById(int id)
        {
            var book = _dbContext
               .Books
               .FirstOrDefault(x => x.Id == id);

            if (book is null) return null;

            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public bool Delete(int id)
        {
            var book = _dbContext
              .Books
              .FirstOrDefault(x => x.Id == id);

            if (book is null) return false;

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            return true;
        }

        public int Add(AddBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }
    }
}
