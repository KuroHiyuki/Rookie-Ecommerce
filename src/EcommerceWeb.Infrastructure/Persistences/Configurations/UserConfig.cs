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
    public sealed class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(e => e.Cart)
                .WithOne(e => e.User)
                .HasForeignKey<Cart>(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(e => e.Reviews)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(e => e.Orders)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //builder.HasMany(e => e.OrderDetails)
            //    .WithOne(e => e.)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
