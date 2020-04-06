using System;
using System.Collections.Generic;
using System.Text;
using gestionpresence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gestionpresence.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            
            modelBuilder.Entity<AppUser>()
                .HasIndex(b => b.CodeRFID)
                .IsUnique();

              base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUSers { get; set; }

    }


}
