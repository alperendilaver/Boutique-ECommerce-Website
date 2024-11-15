using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity; // {{ edit_1 }}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistance.Context
{
    public class NazOzturkContext : IdentityDbContext<AppUser,AppRole,string>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 2, 0));
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=nazozturkdb;user=root;password=1453",serverVersion);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{


        //var connectionString = "server=127.0.0.1;port=3306;database=nazozturk;user=root;password=1453";
        //var serverVersion = new MySqlServerVersion(new Version(8,2,0)); // Adjust this version number based on your MySQL version.
        //optionsBuilder.UseMySql(connectionString, serverVersion);
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductRouteLog> ProductRouteLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole {Id="47a1c433-6709-49db-82e0-d65d934b75a6", Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Name = "Member", NormalizedName = "MEMBER" }
            );

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { Id = "fa510d70-c31f-4fcd-9940-947c32249bd8", Email = "admin@gmail.com", PasswordHash = "sa", UserName = "admin", NormalizedEmail = "ADM�N@GMAIL.COM",FullName="admin" }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "47a1c433-6709-49db-82e0-d65d934b75a6", UserId = "fa510d70-c31f-4fcd-9940-947c32249bd8" }
            );
        }
    }
}