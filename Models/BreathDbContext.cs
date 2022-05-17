using Microsoft.EntityFrameworkCore;
using BreathWebAPI.Models;

namespace BreathWebAPI.Models
{

    public class BreathDbContext : DbContext 
    {
        public BreathDbContext(DbContextOptions<BreathDbContext> options)
            : base(options)
        {
        }    
    }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Therapist> Therapists { get; set; }

    public DbSet<User> Users { get; set; }

}
