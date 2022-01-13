
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace angular.Models
{
}
    public class AppDataContext : DbContext
    {
        public DbSet<Note> Note { get; set; }
        public DbSet<User> User { get; set; }


        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }   
