using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthoLastName { get; set; }
        public string Title { get; set; }
        public string TypeOfBook { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? IdBookStatus { get; set; }
        public virtual BookStatus Status { get; set; }
    }
}
