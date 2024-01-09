using Microsoft.EntityFrameworkCore;
using Trip_project.Models;

namespace Trip_project.Data
{
    public class TripdbContext :DbContext
    {

        public TripdbContext(DbContextOptions dbContextOptions): base(dbContextOptions) { 
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
