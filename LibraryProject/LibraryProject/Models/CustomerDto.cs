﻿using System;
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
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
