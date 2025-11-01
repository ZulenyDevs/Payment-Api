using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.Payments;
using Payment.Domain.Providers;
using Payment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.DomainModel.Config
{
    internal class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("service");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("name").IsRequired().HasMaxLength(255);
            builder.Property(p => p.CategoryId).HasColumnName("category_id").IsRequired();
            builder.Property(p => p.ProviderId).HasColumnName("provider_id").IsRequired();

            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Provider>()
                   .WithMany()
                   .HasForeignKey(x => x.ProviderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
