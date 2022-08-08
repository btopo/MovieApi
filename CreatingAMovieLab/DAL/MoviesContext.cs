using CreatingAMovieLab.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatingAMovieLab.DAL
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
            // Nothing needed
        }

        public DbSet<Movies> Movies { get; set; }
    }

}
