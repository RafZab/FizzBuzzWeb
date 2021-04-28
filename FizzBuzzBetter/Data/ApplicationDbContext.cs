using FizzBuzz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzBetter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Fizzbuzz> Fizzbuzz { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
