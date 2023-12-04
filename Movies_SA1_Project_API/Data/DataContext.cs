using Microsoft.EntityFrameworkCore;
using Movies_SA1_Project_API.Models;

namespace Movies_SA1_Project_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        // creates the database
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
