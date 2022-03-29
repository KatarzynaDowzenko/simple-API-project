using LibraryProject.Entities;
using LibraryProject.Models;
using AutoMapper;
using System;

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

            CreateMap<AddBorrowedBookDto, BorrowedBook>()
                .ForMember(x => x.DateOfBorrowingBook, s => s.MapFrom(m => DateTime.Now));

            CreateMap<AddCustomerDto, Customer>();

            CreateMap<UpdateBookDto, Book>();

            CreateMap<UpdateBorrowedBookDto, BorrowedBook>();

            CreateMap<UpdateCustomerDto, BorrowedBook>();
        }
    }
}
