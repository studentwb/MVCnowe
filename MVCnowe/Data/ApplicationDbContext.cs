using Microsoft.EntityFrameworkCore;
using MVCnowe.Models;

namespace MVCnowe.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)// co to robi
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
      
    }
}
