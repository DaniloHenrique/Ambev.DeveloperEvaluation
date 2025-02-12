using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Description).IsUnique();

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder
                .Property(c => c.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);
        }
    }
}
