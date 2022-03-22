using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using LibraryProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
