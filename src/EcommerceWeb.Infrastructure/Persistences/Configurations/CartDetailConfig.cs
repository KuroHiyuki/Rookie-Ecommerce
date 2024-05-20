using EcommerceWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Persistences.Configurations
{
    public sealed class CartDetailConfig : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasOne(e => e.Cart)
                .WithMany(e => e.CartDetails)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.Product)
               .WithMany(e => e.CartDetails)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
