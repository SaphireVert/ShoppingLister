
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace angular.Models
{
}
    public class AppDataContext : DbContext
    {
        public DbSet<T_List> T_List { get; set; }
        public DbSet<T_Item> T_Item { get; set; }
        public DbSet<T_Product> T_Product { get; set; }
        public DbSet<T_Category> T_Category { get; set; }
        // public DbSet<ItemItemList> ItemItemList { get; set; }
        // public DbSet<Dictionary<string, object>> Products => Set<Dictionary<string, object>>("Product");
        // public DbSet<Dictionary<string, object>> ItemItemList => Set<Dictionary<string, object>>("ItemItemList");


        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            // modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Product", b =>
            // {
            //     b.IndexerProperty<int>("Id");
            //     b.IndexerProperty<string>("Name").IsRequired();
            //     b.IndexerProperty<decimal>("Price");
            // });

    }
    }   
