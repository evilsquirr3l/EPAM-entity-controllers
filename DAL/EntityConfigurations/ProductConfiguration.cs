using System.Collections.Generic;
using EPAM_entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EPAM_entity.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products);

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
            
        }
    }
}