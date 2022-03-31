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
            CreateMap<Book, BookDto>()
                .ForMember(x => x.Status, s => s.MapFrom(m => m.Status.Status));

            CreateMap<BorrowedBook, BorrowedBookDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<AddBookDto, Book>();

            CreateMap<AddBorrowedBookDto, BorrowedBook>()
                .ForMember(x => x.DateOfBorrowingBook, s => s.MapFrom(m => DateTime.Now));

            CreateMap<AddCustomerDto, Customer>();

            CreateMap<UpdateBookStatusDto, Book>();

            CreateMap<ReturnBorrowedBookDto, BorrowedBook>();

            CreateMap<UpdateCustomerDto, BorrowedBook>();
        }
    }
}