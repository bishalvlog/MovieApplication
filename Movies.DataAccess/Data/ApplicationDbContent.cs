using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Models;

namespace Movies.DataAccess.Data
{
    public class ApplicationDbContent : IdentityDbContext
    {
        public ApplicationDbContent(DbContextOptions<ApplicationDbContent> options) :base (options)
        {

        }
       public DbSet<movie> movies { get; set; }  
       public DbSet<moviecost>moviecosts { get; set; }    
       public DbSet<moviedetails>moviedetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<movie>()
                 .HasMany(movie => movie.details)
                 .WithOne(detail => detail.movies)
                 .HasForeignKey(detail => detail.Id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
