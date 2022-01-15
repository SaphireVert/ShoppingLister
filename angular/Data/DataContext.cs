
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
        // public DbSet<ItemItemList> ItemItemList { get; set; }
        // public DbSet<Dictionary<string, object>> Products => Set<Dictionary<string, object>>("Product");
        // public DbSet<Dictionary<string, object>> ItemItemList => Set<Dictionary<string, object>>("ItemItemList");


        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Product", b =>
            {
                b.IndexerProperty<int>("Id");
                b.IndexerProperty<string>("Name").IsRequired();
                b.IndexerProperty<decimal>("Price");
            });

    }
    }   
