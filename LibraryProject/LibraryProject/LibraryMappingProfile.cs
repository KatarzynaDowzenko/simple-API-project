using LibraryProject.Entities;
using LibraryProject.Models;
using AutoMapper;

namespace LibraryProject
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<BorrowedBook, BorrowedBookDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<AddBookDto, Book>();

            CreateMap<AddBorrowingBookDto, BorrowedBook>();

            CreateMap<AddCustomerDto, Customer>();

            CreateMap<UpdateBookDto, Book>();            
        }
    }
}
