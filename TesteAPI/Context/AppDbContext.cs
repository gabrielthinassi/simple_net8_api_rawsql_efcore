using Microsoft.EntityFrameworkCore;
using TesteAPI.Models;

namespace TesteAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
