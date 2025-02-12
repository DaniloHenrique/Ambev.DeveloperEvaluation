using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();

            builder
                .Property(p=>p.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p=>p.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.Image)
                .HasMaxLength(2048);

            builder
                .HasOne(p => p.Rating)
                .WithOne(r=>r.Product)
                .HasForeignKey<Rating>(r=>r.ProductId)
                .IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p=>p.CategoryId)
                .IsRequired();
        }
    }
}
