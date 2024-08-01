using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Data
{

    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
    

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Roles> Roles { get; set; }

        // public DbSet<BlogUserXref> BlogUserXref { get; set;}

        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<Roles> roles = new List<Roles>
            {
                new Roles
                {
                    Name = "User",
                    NormalizedName ="USER",
                    CreatedDate = DateTime.Now

                },

                new Roles
                {
                    Name = "Admin",
                    NormalizedName ="ADMIN",
                    CreatedDate = DateTime.Now
                },
                new Roles
                {
                    Name = "ReadyOnly",
                    NormalizedName ="READONLY",
                    CreatedDate = DateTime.Now
                },
            };
             modelBuilder.Entity<Roles>().HasData(roles);
        }
    }
}