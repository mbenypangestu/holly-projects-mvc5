using Microsoft.EntityFrameworkCore;
using HollyProject.Models;

namespace MvcMovie.Data
{
    public class HollyProjectContext : DbContext
    {
        public HollyProjectContext(DbContextOptions<HollyProjectContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<HollyProject.Models.Role> Role { get; set; }
    }
}