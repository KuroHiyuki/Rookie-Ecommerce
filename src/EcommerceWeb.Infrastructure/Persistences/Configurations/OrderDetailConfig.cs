using EcommerceWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Persistences.Configurations
{
    public sealed class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {

            builder.HasOne(e => e.Order)
                .WithMany(e => e.Details)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.Product)
               .WithMany(e => e.OrderDetails)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
