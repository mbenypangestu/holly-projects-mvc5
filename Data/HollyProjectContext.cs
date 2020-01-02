using Microsoft.EntityFrameworkCore;
using HollyProject.Models;

namespace HollyProject.Data
{
    public class HollyProjectContext : DbContext
    {
        public HollyProjectContext(DbContextOptions<HollyProjectContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<HollyProject.Models.Booking> Booking { get; set; }
    }
}