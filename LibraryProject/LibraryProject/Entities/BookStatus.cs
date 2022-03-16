using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Entities
{
    public class BookStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
