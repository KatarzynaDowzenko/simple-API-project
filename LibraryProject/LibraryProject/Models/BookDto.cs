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

namespace LibraryProject.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
