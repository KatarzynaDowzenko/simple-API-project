using AutoMapper;
using LibraryProject.Entities;
using LibraryProject.Exceptions;
using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAll();
        BookDto GetById(int id);
        int Add(AddBookDto dto);
        void UpdateStatus(int id, UpdateBookStatusDto dto);
        void Delete(int id);       
    }

    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(LibraryDbContext dbContext, IMapper mapper, ILogger<BookService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<BookDto> GetAll()
        {
            var books = _dbContext
                .Books
                .Include(x => x.Status)
                .ToList();

            var booksDto = _mapper.Map<List<BookDto>>(books);

            return booksDto;
        }

        public BookDto GetById(int id)
        {
            var book = _dbContext
               .Books
               .Include(x => x.Status)
               .FirstOrDefault(x => x.Id == id);

            if (book is null)
            {
                throw new NotFoundException("Book not found");
            }

            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public int Add(AddBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public void UpdateStatus(int id, UpdateBookStatusDto dto)
        {
            var book = _dbContext
             .Books
             .FirstOrDefault(x => x.Id == id);

            if (book is null)
            {
                throw new NotFoundException("Book not found");
            }
                     
            book.BookStatusId = dto.BookStatusId;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _logger.LogError($"Book with id: {id} DELETE action invoked");

            var book = _dbContext
              .Books
              .FirstOrDefault(x => x.Id == id);

            if (book is null)
            {
                throw new NotFoundException("Book not found");
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}