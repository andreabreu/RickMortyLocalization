using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    class RickMap : IEntityTypeConfiguration<Rick>
    {
        public void Configure(EntityTypeBuilder<Rick> builder)
        {
            builder.ToTable("Rick");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Age)
               .HasConversion(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("Age")
               .HasColumnType("int(4)");

            builder.Property(prop => prop.Occupation)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Occupation")
                .HasColumnType("varchar(100)");
        }
    }
}
