using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfiguration
{
  public class CustomerEntityConfiguration :  IEntityTypeConfiguration<CustomerEntity>
  {
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
      builder.ToTable("Customers","Customer");
    }
  }
}