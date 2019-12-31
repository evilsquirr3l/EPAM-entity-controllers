using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EPAM_entity.Entities;
using EPAM_entity.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EPAM_entity
{
    public class ProductContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        public ProductContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = builder.GetConnectionString("DefaultConnection");
            
            optionsBuilder.UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());


            #region AddStartInfoToDb
            
            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                new Category() { CategoryId = 1, Name = "Cars" },
                new Category() { CategoryId = 2, Name = "Tea" },
                new Category() { CategoryId = 3, Name =  "Phones" }
            });

            modelBuilder.Entity<Supplier>().HasData(new List<Supplier>()
            {
                 new Supplier() { SupplierId = 1, Name = "Serhii Denshchyk" },
                 new Supplier() { SupplierId = 2, Name = "Illya Ostrovsky" },
                 new Supplier() { SupplierId = 3, Name = "Danylo Kaminsky" }
            });

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    Price = 399,
                    CategoryId = 1,
                    ProductName = "Lamborgini",
                    SupplierId = 1
                },
                
                new Product()
                {
                    ProductId = 2,
                    Price = 9,
                    CategoryId = 2,
                    ProductName = "Marrokans Mint",
                    SupplierId = 2
                },
                
                new Product()
                {
                    ProductId = 3,
                    Price = 9,
                    CategoryId = 3,
                    ProductName = "IPhone 4s",
                    SupplierId = 3
                }
            });
            
            #endregion
        }
        
    }
    
}