using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BreathWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreathWebAPI.Models
{

    public class BreathDbContext : DbContext
    {
        public BreathDbContext(DbContextOptions<BreathDbContext> options)
            : base(options)
        {
        }    
    

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Therapist> Therapists { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserForeignKey);

        }

    }   
}

