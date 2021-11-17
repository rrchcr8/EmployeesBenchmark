using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));

            builder.HasKey(employee => employee.Id);

            builder.Property(employee => employee.Name).HasMaxLength(60);

            builder.Property(employee => employee.Email).IsRequired();

            builder.Property(employee => employee.JobTitle).HasMaxLength(100);
            builder.Property(employee => employee.Phone).HasMaxLength(100);
            builder.Property(employee => employee.ImageUrl).IsRequired();
            builder.Property(employee => employee.EmployeeCode).IsRequired();


        }
    }
}
