using Microsoft.EntityFrameworkCore;
using EcommerceWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceWeb.Infrastructure.Persistences.Configurations
{
    public sealed class ProductConfig : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
        }
    }
}
