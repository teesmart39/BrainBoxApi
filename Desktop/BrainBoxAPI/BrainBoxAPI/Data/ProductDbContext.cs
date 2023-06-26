using BrainBoxAPI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BrainBoxAPI.Data
{
    //public class ProductDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public DbSet<Product> Products { get; set; }

    //    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //        SeedRoles(builder);
    //    }
    //    public static void SeedRoles(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>().HasData(
    //            new IdentityRole() { Name = "ADMIN", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
    //            new IdentityRole() { Name = "USER", ConcurrencyStamp = "2", NormalizedName = "USER" });
    //    }

    //}
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}