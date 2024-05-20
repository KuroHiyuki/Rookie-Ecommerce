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
    public sealed class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            //builder.HasOne(e => e.UserId)
            //    .WithOne(e => e.Cast)
            //    .HasForeignKey(e => e.)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
