using Microsoft.EntityFrameworkCore;
using FizzBuzz.Models;


namespace FizzBuzz.Data
{
    public class FizzBuzzContext : DbContext
    {
        public DbSet<Fizzbuzz> Fizzbuzz { get; set; }
        public FizzBuzzContext(DbContextOptions options) : base(options) { }

    }
}
