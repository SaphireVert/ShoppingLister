
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace angular.Models
{
}
    public class AppDataContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemList> ItemList { get; set; }


        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }   
