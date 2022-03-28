using System.Collections.Generic;
using System.Linq;
using LibraryProject.Entities;
using System;

namespace LibraryProject
{
    public class LibrarySeeder
    {
        private readonly LibraryDbContext _dbContext;
        public LibrarySeeder(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void SeedBookStatus()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.BooksStatus.Any())
                {
                    var booksStatus = GetBookStatus();
                    _dbContext.BooksStatus.AddRange(booksStatus);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<BookStatus> GetBookStatus()
        {
            var bookStatus = new List<BookStatus>()
            {
                new BookStatus()
                {
                    Status = "new"
                },
                new BookStatus()
                {
                    Status = "good"
                },
                new BookStatus()
                {
                    Status = "signs of use"
                },
                new BookStatus()
                {
                    Status = "old / damaged"
                },
            };
            return bookStatus;
        }

        public void SeedBooks()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Books.Any())
                {
                    var books = GetBooks();
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    AuthorName = "Joseph",
                    AuthorLastName = "Heller",
                    Title = "Paragraph 22",
                    TypeOfBook = "humorous prose and a war novel",
                    IsAvailable = true,
                    ReleaseDate = new DateTime(1961,11,10),
                    BookStatusId = 3
                },

                new Book()
                {
                    AuthorName = "John Ronald Reuel",
                    AuthorLastName = "Tolkien",
                    Title = "The Lord Of The Rings",
                    TypeOfBook = "fantasy",
                    IsAvailable = false,
                    ReleaseDate = new DateTime(1954,07,29),
                    BookStatusId = 3
                },

                new Book()
                {
                    AuthorName = "Francis Scott",
                    AuthorLastName = "Fitzgerald",
                    Title = "The Great Gatsby",
                    TypeOfBook = "novel",
                    IsAvailable = true,
                    ReleaseDate = new DateTime(1925,04,10),
                    BookStatusId = 2
                },

                new Book()
                {
                    AuthorName = "Brandon",
                    AuthorLastName = "Sanderson",
                    Title = "The Way of Kings",
                    TypeOfBook = "fantasy",
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2010,08,31),
                    BookStatusId = 1
                },

                new Book()
                {
                    AuthorName = "Carlos Ruiz",
                    AuthorLastName = "Zafón",
                    Title = "The Angel's Game",
                    TypeOfBook = "Criminal story",
                    IsAvailable = false,
                    ReleaseDate = new DateTime(2008,04,17),
                    BookStatusId = 3
                }
            };
            return books;
        }

    }
}

