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
                
            CreateMap<BorrowedBook, BorrowedBookDto>()
                .ForMember(m => m.BookId, c => c.MapFrom(s => s.BookId));

            CreateMap<Customer, CustomerDto>();

            CreateMap<AddBookDto, Book>();

            CreateMap<AddBorrowingBookDto, BorrowedBook>()
                .ForMember(m => m.BookId, c => c.MapFrom(s => s.BookId))
                .ForMember(m => m.CustomerId, c => c.MapFrom(s => s.CustomerId));

            CreateMap<AddCustomerDto, Customer>();
        }
    }
}
